﻿using Polideportivo.AccesoDatos;
using Polideportivo.Controlador;
using Polideportivo.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Polideportivo.Vista.utilidadForms;

namespace Polideportivo.Vista
{
    public partial class formJugadorEventos : Form
    {


        public formJugadorEventos()
        {
            InitializeComponent();
        }


        formJugador formOriginal = new formJugador();

        modeloJugador modeloOriginal;
        public formJugadorEventos(modeloJugador modelo, formJugador form)
        {
            // Este constructor es el que se utiliza para modificar datos
            InitializeComponent();
            btnAgregarJugador.Visible = false;
            btnModificarJugador.Visible = true;
            formOriginal = form;
            txtNombre.Text = modelo.nombre;
            txtAnotaciones.Text = modelo.anotaciones.ToString();
            // Llenar combobox de deportes
            controladorDeporte deportes = new controladorDeporte();
            cboDeporte.DataSource = deportes.mostrarDeportes();
            cboDeporte.DisplayMember = "nombre";
            cboDeporte.ValueMember = "pkId";

            // Para obtener el Id original que se va a modificar
            modeloOriginal = modelo;

        }


        public formJugadorEventos(formJugador form)
        {
            // Este constructor es el que se utiliza para agregar datos
            InitializeComponent();
            btnAgregarJugador.Visible = true;
            btnModificarJugador.Visible = false;
            // Llenar combobox de deportes
            controladorDeporte deportes = new controladorDeporte();
            cboDeporte.DataSource = deportes.mostrarDeportes();
            cboDeporte.DisplayMember = "nombre";
            cboDeporte.ValueMember = "pkId";
            cboDeporte.SelectedIndex = -1;
            formOriginal = form;
        }



        private void formJugadorEventos_Load(object sender, EventArgs e)
        {
            

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void parrotGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void cboEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Actualizar el combobox de roles dependiendo del deporte seleccionado
        private void cboDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDeporte.SelectedIndex > -1)
            {
                // Llenar la combobox de rol dependiendo del deporte elegido
                modeloRol modelorol = new modeloRol();
                modelorol.fkIdDeporte = stringAInt(cboDeporte.SelectedValue.ToString());
                controladorRol rol = new controladorRol(modelorol);
                cboRol.DataSource = rol.mostrarRolesPorDeporte();
                cboRol.DisplayMember = "nombre";
                cboRol.ValueMember = "pkId";

                // Llenar la combobox de equipo dependiendo del deporte elegido
                modeloEquipo modeloequipo = new modeloEquipo();
                modeloequipo.fkIdDeporte = stringAInt(cboDeporte.SelectedValue.ToString());
                controladorEquipo equipo = new controladorEquipo(modeloequipo);
                cboEquipo.DataSource = equipo.mostrarEquipoPorDeporte();
                cboEquipo.DisplayMember = "nombre";
                cboEquipo.ValueMember = "pkId";
            }
        }

        private void cboDeporte_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cboDeporte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //controladorRol rol = new controladorRol();
            //modeloRol modelo = new modeloRol();
            //modelo.fkIdDeporte = utilidadForms.stringAInt(cboDeporte.SelectedValue.ToString());
            //cboRol.DataSource = rol.mostrarRolesPorDeporte(modelo);
            //cboRol.DisplayMember = "nombre";
            //cboRol.ValueMember = "pkId";
        }

        private void cboDeporte_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            controladorJugador modeloAgregar = new controladorJugador();
            modeloJugador modelo = new modeloJugador();
            modelo.nombre = txtNombre.Text;
            modelo.anotaciones = stringAInt(txtAnotaciones.Text);
            modelo.fkIdDeporte = stringAInt(cboDeporte.SelectedValue.ToString());
            modelo.fkIdEquipo = stringAInt(cboEquipo.SelectedValue.ToString());
            modelo.fkIdRol = stringAInt(cboRol.SelectedValue.ToString());
            modeloAgregar.agregarJugador(modelo);
            formOriginal.actualizarTablaJugadores();
            cerrarForm(this);
        }

        private void btnModificarJugador_Click(object sender, EventArgs e)
        {
            controladorJugador modeloModificar = new controladorJugador();
            modeloJugador modelo = new modeloJugador();
            modelo.pkId = modeloOriginal.pkId;
            modelo.nombre = txtNombre.Text;
            modelo.anotaciones = stringAInt(txtAnotaciones.Text);
            modelo.fkIdDeporte = stringAInt(cboDeporte.SelectedValue.ToString());
            modelo.fkIdEquipo = stringAInt(cboEquipo.SelectedValue.ToString());
            modelo.fkIdRol = stringAInt(cboRol.SelectedValue.ToString());
            modeloModificar.modificarJugador(modelo);
            formOriginal.actualizarTablaJugadores();
            cerrarForm(this);
        }
    }
}
