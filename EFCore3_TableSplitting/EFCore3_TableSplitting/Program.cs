using EFCore3_TableSplitting.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCore3_TableSplitting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using(var ctx = new ApplicationDbContext())
            {
                // No se incluyen datos de EstudianteDetalle
                var estudiantes = ctx.Estudiantes.ToList();

                // Se incluyen datos de EstudianteDetalle
                var EstudiantesConDetalle = ctx.Estudiantes.Include(x => x.Detalles).ToList();

                // Insertar un estudiante con su detalle
                var estudiante = new Estudiante();
                estudiante.Nombre = "Pedro Páramo";
                var detalle = new EstudianteDetalle();
                detalle.Cedula = "123-456-789";

                estudiante.Detalles = detalle;

                ctx.Add(estudiante);
                ctx.SaveChanges();

            //    // Para actualizar el detalle de un estudiante que ya existe
            //    var pedro = ctx.Estudiantes.First(x => x.Nombre == "Pedro Páramo");

            //    var detallePedro = new EstudianteDetalle();
            //    detallePedro.Cedula = "987-654-321-0";

            //    pedro.Detalles = detallePedro;

            //    ctx.EstudianteDetalles.Update(pedro);
            //    ctx.SaveChanges();
            }
        }
    }
}
