using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppLogic
{
    public class ParametroManager : IParametroManager
    {
        private readonly ParametroCrud _parametroCrud;

        public ParametroManager()
        {
            _parametroCrud = new ParametroCrud();
        }

        public void Create(ParametroDTO parametro)
        {
            ValidateValorByTipoDato(parametro.Valor, parametro.TipoDato);
            _parametroCrud.Create(parametro);
        }

        public void UpdateParametro(ParametroUpdateDTO dto)
        {
            var existing = _parametroCrud.RetrieveById<ParametroDTO>(dto.Id).FirstOrDefault();

            if (existing == null)
                throw new Exception("Parámetro no encontrado.");

            if (!existing.EsEditable)
                throw new Exception("Este parámetro no es editable.");

            ValidateValorByTipoDato(dto.Valor, existing.TipoDato);

            existing.Valor = dto.Valor;
            existing.UsuarioActualizaId = dto.UsuarioActualizaId;

            _parametroCrud.Update(existing);
        }

        public List<ParametroDTO> RetrieveAll()
        {
            return _parametroCrud.RetrieveAll<ParametroDTO>();
        }

        public List<ParametroDTO> RetrieveById(int id)
        {
            return _parametroCrud.RetrieveById<ParametroDTO>(id);
        }

        public List<ParametroDTO> RetrieveByCategoria(string categoria)
        {
            return _parametroCrud.RetrieveByCategoria<ParametroDTO>(categoria);
        }

        public List<ParametroDTO> RetrieveByClave(string clave)
        {
            return _parametroCrud.RetrieveByClave<ParametroDTO>(clave);
        }

        private void ValidateValorByTipoDato(string valor, string tipoDato)
        {
            if (string.IsNullOrWhiteSpace(tipoDato))
                throw new Exception("El tipo de dato del parámetro no es válido.");

            if (valor == null)
                throw new Exception("El valor no puede ser nulo.");

            switch (tipoDato.Trim().ToUpper())
            {
                case "INT":
                    if (!int.TryParse(valor, out _))
                        throw new Exception("El valor debe ser un número entero.");
                    break;

                case "DECIMAL":
                    if (!decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out _) &&
                        !decimal.TryParse(valor, NumberStyles.Any, CultureInfo.CurrentCulture, out _))
                    {
                        throw new Exception("El valor debe ser un número decimal.");
                    }
                    break;

                case "VARCHAR":
                    if (string.IsNullOrWhiteSpace(valor))
                        throw new Exception("El valor de texto no puede estar vacío.");
                    break;

                case "BIT":
                case "BOOL":
                case "BOOLEAN":
                    if (!bool.TryParse(valor, out _) && valor != "0" && valor != "1")
                        throw new Exception("El valor debe ser booleano.");
                    break;

                default:
                    throw new Exception($"TipoDato no soportado: {tipoDato}");
            }
        }
    }
}
