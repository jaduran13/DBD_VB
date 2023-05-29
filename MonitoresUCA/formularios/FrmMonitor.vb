Public Class FrmMonitor

    Private dCiudad As New CiudadDao
    Private dMateria As New MateriaDao
    Private dMonitor As New MonitorDao

    Sub LlenarCiudad()
        Try
            CmbCiudad.DataSource = dCiudad.MostrarRegistros.Tables(0)
            CmbCiudad.DisplayMember = "nombre"
            CmbCiudad.ValueMember = "id"
            CmbCiudad.Refresh()
        Catch ex As Exception
            MsgBox("Error al mostrar ciudades", MsgBoxStyle.Critical, "Monitores")
        End Try
    End Sub

    Sub LlenarMateria()
        Try
            CmbMateria.DataSource = dMateria.MostrarRegistros.Tables(0)
            CmbMateria.DisplayMember = "nombre"
            CmbMateria.ValueMember = "id"
            CmbMateria.Refresh()
        Catch ex As Exception
            MsgBox("Error al mostrar materia", MsgBoxStyle.Critical, "Monitores")
        End Try
    End Sub

    Private Sub FrmMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarCiudad()
        LlenarMateria()
        MostrarRegistros()
    End Sub

    Sub Limpiar()
        TxtIDUca.Clear()
        TxtPrimerN.Clear()
        TxtSegundoN.Clear()
        TxtPrimerA.Clear()
        TxtSegundoA.Clear()
        TxtDireccion.Clear()
        TxtEmail.Clear()
        TxtObservacion.Clear()
        TxtValor.Clear()
        CmbCiudad.SelectedIndex = -1
        CmbMateria.SelectedIndex = -1
        CmbCampo.SelectedIndex = -1
        DtpFechaNac.Value = Now
        TabControl1.SelectedIndex = 0
        TxtIDUca.Focus()
    End Sub
    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Limpiar()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim monitor As New MonitorEntity
            monitor.IdUCA = TxtIDUca.Text
            monitor.PrimerNombre = TxtPrimerN.Text
            monitor.SegundoNombre = TxtSegundoN.Text
            monitor.PrimerApellido = TxtPrimerA.Text
            monitor.SegundoApellido = TxtSegundoA.Text
            monitor.FechaNac = DtpFechaNac.Value
            monitor.Ciudad.Id = CmbCiudad.SelectedValue
            monitor.Ciudad.Nombre = CmbCiudad.Text
            monitor.Direccion = TxtDireccion.Text
            monitor.Email = TxtEmail.Text
            monitor.Materia.Id = CmbMateria.SelectedValue
            monitor.Materia.Nombre = CmbMateria.Text
            monitor.Observaciones = TxtObservacion.Text

            If (dMonitor.GuardarRegistro(monitor) = True) Then
                MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Monitores")
            Else
                MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Exclamation, "Monitores")
            End If
        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Monitores")
        End Try
        MostrarRegistros()
    End Sub

    Sub DiseñoGrid()
        'Ocultar filas
        DgvRegistros.Columns(0).Visible = False
        DgvRegistros.Columns(7).Visible = False
        DgvRegistros.Columns(11).Visible = False
        DgvRegistros.Columns(14).Visible = False
        'Poner titulos o encabezados
        DgvRegistros.Columns(1).HeaderText = "CODIGO UCA"
        DgvRegistros.Columns(2).HeaderText = "PRIMER NOMBRE"
        DgvRegistros.Columns(3).HeaderText = "SEGUNDO NOMBRE"
        DgvRegistros.Columns(4).HeaderText = "PRIMER APELLIDO"
        DgvRegistros.Columns(5).HeaderText = "SEGUNDO APELLIDO"
        DgvRegistros.Columns(6).HeaderText = "CUMPLEAÑO"
        DgvRegistros.Columns(8).HeaderText = "CIUDAD"
        DgvRegistros.Columns(9).HeaderText = "DIRECCION"
        DgvRegistros.Columns(10).HeaderText = "EMAIL"
        DgvRegistros.Columns(11).HeaderText = "TELEFONO"
        DgvRegistros.Columns(12).HeaderText = "MATERIA"
        DgvRegistros.Columns(13).HeaderText = "OBSERVACIONES"

    End Sub

    Sub MostrarRegistros()
        Try
            DgvRegistros.DataSource = dMonitor.MostrarRegistros.Tables(0)
            DgvRegistros.Refresh()
            DiseñoGrid()
            GbRegistros.Text = "Registros almacenados: " & DgvRegistros.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Try
            Dim monitor As New MonitorEntity
            monitor.IdUCA = TxtIDUca.Text
            monitor.PrimerNombre = TxtPrimerN.Text
            monitor.SegundoNombre = TxtSegundoN.Text
            monitor.PrimerApellido = TxtPrimerA.Text
            monitor.SegundoApellido = TxtSegundoA.Text
            monitor.FechaNac = DtpFechaNac.Value
            monitor.Ciudad.Id = CmbCiudad.SelectedValue
            monitor.Ciudad.Nombre = CmbCiudad.Text
            monitor.Direccion = TxtDireccion.Text
            monitor.Email = TxtEmail.Text
            monitor.Materia.Id = CmbMateria.SelectedValue
            monitor.Materia.Nombre = CmbMateria.Text
            monitor.Observaciones = TxtObservacion.Text

            If (dMonitor.EditarRegistro(monitor) = True) Then
                MsgBox("Registro modificado satisfactoriamente.", MsgBoxStyle.Information, "Monitores")
            Else
                MsgBox("No se pudo modificar el registro...", MsgBoxStyle.Exclamation, "Monitores")
            End If
        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Monitores")
        End Try
        MostrarRegistros()
    End Sub
End Class