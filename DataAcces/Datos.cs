using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAcces
{
    public static class Datos
    {
        public static List<Personas> CargarDatos()
        {
            using (DatabaseEntities bd = new DatabaseEntities())
            {
               var datos = (from p in bd.Personas select p).ToList();

                return datos;
            }
        }

        public static List<Personas> Buscar(string nombre)
        {
            using (DatabaseEntities bd = new DatabaseEntities())
            {
                var buscar = (from p in bd.Personas
                              where p.Nombre.StartsWith(nombre)
                              select p).ToList();

                return buscar;                
            }
        }

        public static void Agregar(string nombre, string apellido, int edad,string profesion)
        {
            using (DatabaseEntities bd = new DatabaseEntities())
            {
                bd.Personas.AddObject(new Personas { Nombre = nombre, Apellido = apellido, Edad = edad, Profesion = profesion });
                bd.SaveChanges();
            }
        }

        public static void Editar(int id,string nombre, string apellido, int edad, string profesion)
        {
            using (DatabaseEntities bd = new DatabaseEntities())
            {
                var editar = (from p in bd.Personas
                              where p.Id == id
                              select p).Single();

                editar.Nombre = nombre;
                editar.Apellido = apellido;
                editar.Edad = edad;
                editar.Profesion = profesion;
                bd.SaveChanges();
            }
        }


        public static Personas ObtenerId(int id)
        {
            Personas persona = new Personas();
            using (DatabaseEntities bd = new DatabaseEntities())
            {
                var regis = (from p in bd.Personas
                              where p.Id==id
                              select p).Single();

                persona.Id = regis.Id;
                persona.Nombre = regis.Nombre;
                persona.Apellido = regis.Apellido;
                persona.Edad = regis.Edad;

                return persona;
            }
        }

        public static void Eliminar(int id)
        {
            using (DatabaseEntities bd = new DatabaseEntities())
            {
                var eliminar = (from p in bd.Personas
                                where p.Id==id
                                select p).Single();

                bd.DeleteObject(eliminar);
                bd.SaveChanges();
            }
        }
    }
}
