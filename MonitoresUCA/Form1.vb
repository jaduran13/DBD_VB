﻿Public Class Form1
    Private Sub AsignaturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaturasToolStripMenuItem.Click
        Dim frm As New FrmMateria
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CiudadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CiudadesToolStripMenuItem.Click
        Dim frm As New FrmCiudad
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub MonitoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonitoresToolStripMenuItem.Click
        Dim frm As New FrmMonitor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MonitoresPorCiudadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonitoresPorCiudadToolStripMenuItem.Click
        Dim tbl As New DataTable
        Dim reporte As New DBMonitoresDataSetTableAdapters.RptMonitorXCiudadTableAdapter

        tbl = reporte.GetData
        VerReporte(tbl, "DataSet1", "reportes\RptMonitorXCiudad.rdlc")
    End Sub
End Class
