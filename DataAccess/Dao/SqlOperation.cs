using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

public class SqlOperation
{
    public string ProcedureName { get; set; }
    public List<SqlParameter> Parameters { get; set; }

    public SqlOperation()
    {
        Parameters = new List<SqlParameter>();
    }

    //metodos para agregar los distintos tipos de parametros

    public void AddVarcharParam(string parameterName, string parameterValue)
    {
        Parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
    }
    public void AddIntParam(string parameterName, int parameterValue)
    {
        Parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
    }
    public void AddDateTimeParam(string parameterName, DateTime parameterValue)
    {
        Parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
    }
    public void AddDecimalParam(string paramName, decimal value)
    {
        Parameters.Add(new SqlParameter("@" + paramName, value));
    }
        public void AddTimeParam(string parameterName, TimeSpan parameterValue)
    {
        Parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
    }
    public void AddBitParam(string parameterName, bool parameterValue)
    {
        Parameters.Add(new SqlParameter("@" + parameterName, parameterValue));
    }


    public void AddIntegerParam(string paramName, int value)
    {
        this.Parameters.Add(new SqlParameter
        {
            ParameterName = paramName,
            Value = value,
            DbType = System.Data.DbType.Int32
        });
    }

    public void AddBooleanParam(string paramName, bool value)
    {
        this.Parameters.Add(new SqlParameter
        {
            ParameterName = paramName,
            Value = value,
            DbType = System.Data.DbType.Boolean
        });
    }
}

