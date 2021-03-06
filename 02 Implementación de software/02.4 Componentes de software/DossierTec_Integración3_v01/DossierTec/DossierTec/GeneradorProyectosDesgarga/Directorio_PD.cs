using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ListasInformacion;

namespace GeneradorProyectosDesgarga
{
    public class Directorio_PD
    {
        string DireccionDirectorio;//Ubicación de donde estará el directorio

        public Directorio_PD(string Direccion)
        {
            this.DireccionDirectorio = Direccion;
        }

        public void CrearDirectorios()
        {
            //Método para recorer la Lista e ir creando los directorios
            Listas.ListaProyectos = Listas.ListaProyectos;
            
            string Docente = "";
            string ProyectoDescarga = "";

            if (Listas.ListaProyectos != null)
            {
                foreach (Proyecto mProyecto in Listas.ListaProyectos) 
                {
                    Docente = mProyecto.Docente;
                    ProyectoDescarga = mProyecto.ProyectoDescarga;

                    // Especificamos la ruta completa del directorio a crear.
                    string path = @"" + this.DireccionDirectorio + "\\Proyectos_Descarga" + "\\" + Docente+ "\\" + ProyectoDescarga + " ";
                    try
                    {
                        // Verifica si el directorio existe.
                        if (Directory.Exists(path))
                        {
                            MessageBox.Show("El directorio ya existe.");
                        }
                        else
                        {
                            //Crea la ruta completa de directorios, junto con sus subcarpetas
                            DirectoryInfo di = Directory.CreateDirectory(path);
                            Console.WriteLine("El directorio ha sido creado {0}.", Directory.GetCreationTime(path));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: {0}", ex.ToString());
                    }
                }
            }
            else 
            {
                MessageBox.Show("Lista Vacia");
            }

   
        }
        
    }
}
