using System;

namespace DTO.Ingeniero
{
    public class ArchivosDTO
    {
        public int IdArchivo { get; set; }
        public int IdDetalle { get; set; }
        public string TipoArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string UrlArchivo { get; set; }
        public DateTime FechaSubida { get; set; }

        public string Extension => System.IO.Path.GetExtension(NombreArchivo)?.ToLower();
        public bool EsImagen => Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".webp" || Extension == ".gif";
        public string TamanioFormateado => FormatearTamanio(TamanioEnBytes);

        public long TamanioEnBytes { get; set; }

        private string FormatearTamanio(long bytes)
        {
            if (bytes <= 0) return "0 B";
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024} KB";
            return $"{bytes / (1024 * 1024)} MB";
        }
    }
}