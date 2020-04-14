using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore3_TableSplitting.Modelos
{
    public class EstudianteDetalle
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public Estudiante Estudiante { get; set; }

    }   //*
}
