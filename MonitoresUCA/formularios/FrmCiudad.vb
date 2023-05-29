Public Class FrmCiudad
    Dim ciudadAct As New CiudadEntity

    Sub MostrarRegistros()
        Dim ciudadDao As New CiudadDao
        DgvRegistros.DataSource = ciudadDao.MostrarRegistros().Tables(0)
        DgvRegistros.Refresh()
        GbRegistros.Text = "Registros Guardados: " & DgvRegistros.Rows.Count
    End Sub

    Private Sub FrmCiudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarRegistros()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        TbNombre.Clear()
        BtnEditar.Enabled = False
        BtnEliminar.Enabled = False
        BtnGuardar.Enabled = True
        TbNombre.Focus()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim ciudad = New CiudadEntity(0, TbNombre.Text, True)
        Dim ciudadDao As New CiudadDao()

        Dim resp = ciudadDao.AgregarRegistro(ciudad)
        If (resp) Then
            MsgBox("Regitro guardado satisfactoriamente", MsgBoxStyle.Information, "Monitores UCA")
        Else
            MsgBox("Error al guardar registro.", MsgBoxStyle.Critical, "Moniores UCA")
        End If
        TbNombre.Clear()
        MostrarRegistros()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Dim ciudadDao As New CiudadDao()
        ciudadAct.Nombre = TbNombre.Text
        Dim resp = ciudadDao.EditarRegistro(ciudadAct)
        If (resp) Then
            MsgBox("Regitro editado satisfactoriamente", MsgBoxStyle.Information, "Monitores UCA")
        Else
            MsgBox("Error al editar registro.", MsgBoxStyle.Critical, "Monitores UCA")
        End If
        MostrarRegistros()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim codigo As Integer = ciudadAct.Id
        Dim ciudadDao As New CiudadDao()
        Dim ciudad As New CiudadEntity()
        ciudad = ciudadDao.BuscarRegistro(codigo)
        If (ciudad.Id = 0) Then
            MsgBox("Registro no existe.", MsgBoxStyle.Exclamation, "Monitores UCA")
            Exit Sub
        End If
        Dim resp As VariantType
        resp = (MsgBox("¿Desea eliminar este registro " & ciudad.Id, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Monitores UCA"))
        If (resp = vbNo) Then
            MsgBox("Operación cancelada", MsgBoxStyle.Information, "Monitores UCA")
            Exit Sub
        End If

        Dim eliminado = ciudadDao.EliminarRegistro(ciudad.Id)
        If (eliminado) Then
            MsgBox("Regitro eliminado satisfactoriamente", MsgBoxStyle.Information, "Monitores UCA")
        Else
            MsgBox("Error al eliminar registro.", MsgBoxStyle.Critical, "Moniores UCA")
        End If
        MostrarRegistros()
    End Sub

    Private Sub DgvRegistros_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvRegistros.MouseDoubleClick
        Dim fila As Integer = DgvRegistros.CurrentRow.Index
        ciudadAct.Id = Integer.Parse(DgvRegistros.Rows(fila).Cells(0).Value)
        ciudadAct.Nombre = DgvRegistros.Rows(fila).Cells(1).Value
        ciudadAct.Estado = DgvRegistros.Rows(fila).Cells(2).Value
        TbNombre.Text = ciudadAct.Nombre
        BtnGuardar.Enabled = False
        BtnEditar.Enabled = True
        BtnEliminar.Enabled = True
        TbNombre.Focus()
    End Sub


End Class