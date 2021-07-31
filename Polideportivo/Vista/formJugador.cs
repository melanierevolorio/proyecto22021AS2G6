﻿using Polideportivo.AccesoDatos;
using Polideportivo.Modelo;
using System;
using System.Windows.Forms;
using static Polideportivo.Vista.utilidadForms;

namespace Polideportivo.Vista
{
    public partial class formJugador : Form
    {




        public formJugador()
        {
            InitializeComponent();
        }

        private void formJugador_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tablaJugadores1.vwjugador' Puede moverla o quitarla según sea necesario.
            vwjugadorTableAdapter.Fill(tablaJugadores1.vwjugador);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            modeloJugador modelo = new modeloJugador();
            controladorJugador db = new controladorJugador();
            db.agregarJugador(modelo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizarTablaJugadores();
        }

        public void actualizarTablaJugadores()
        {
            this.vwjugadorTableAdapter.Fill(this.tablaJugadores1.vwjugador);
        }


        private void txtJugadorFiltrar_TextChanged(object sender, EventArgs e)
        {

        }

        modeloJugador modeloFila = new modeloJugador();
        private void tablaJugadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string nombre = tablaJugadores.SelectedRows[0].Cells[1].Value.ToString();
            int id = stringAInt(tablaJugadores.SelectedRows[0].Cells[0].Value.ToString());
            int anotaciones = stringAInt(tablaJugadores.SelectedRows[0].Cells[2].Value.ToString());
            int fkIdEquipo = stringAInt(tablaJugadores.SelectedRows[0].Cells[3].Value.ToString());
            int fkIdRol = stringAInt(tablaJugadores.SelectedRows[0].Cells[5].Value.ToString());
            int fkIdDeporte = stringAInt(tablaJugadores.SelectedRows[0].Cells[7].Value.ToString());
            modeloFila.pkId = id;
            modeloFila.nombre = nombre;
            modeloFila.anotaciones = anotaciones;
            modeloFila.fkIdEquipo = fkIdEquipo;
            modeloFila.fkIdRol = fkIdRol;
            modeloFila.fkIdDeporte = fkIdDeporte;
            // Para que la selección de filas funcione para modificar, tiene que enviarse el
            // modelo a la función de abrirForm:
            // utilidadForms.abrirForm(new formJugadorEventos(modeloFila, this));
            // Además de eso, modificar el construtor del form que va a utilizar los datos
            // para la modificación, en este caso sería el ctor de formJugadorEventos que recibe el modelo

        }


        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            abrirForm(new formJugadorEventos(this));
        }




        private void btnModificarJugador_Click(object sender, EventArgs e)
        {
            abrirForm(new formJugadorEventos(modeloFila, this));
        }
    }
}
