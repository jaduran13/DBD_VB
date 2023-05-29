Public Class FrmMateria

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim mat As New DBMonitoresDataSetTableAdapters.MateriaTableAdapter
        mat.InsertQuery(TbNombre.Text, True)
        MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Monitores")
        LLenarGrid()
    End Sub

    Sub LLenarGrid()
        Try
            Dim mat As New DBMonitoresDataSetTableAdapters.MateriaTableAdapter
            DgvRegistros.DataSource = mat.GetData
            DgvRegistros.Refresh()
            GbRegistros.Text = "Registros almacenados: " & DgvRegistros.Rows.Count
        Catch ex As Exception
            MsgBox("Error al mostrar datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FrmMateria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LLenarGrid()
    End Sub
End Class