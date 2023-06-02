Imports Microsoft.Reporting.WinForms


Module MiModulo
    Sub VerReporte(ByVal t As DataTable, ByVal nombreDs As String, ByVal nombreRpt As String)

        Try
            Dim rpt As New ReportDataSource(nombreDs, t)
            With New FrmVistaPrevia
                .ReportViewer1.LocalReport.DataSources.Clear()
                .ReportViewer1.LocalReport.DataSources.Add(rpt)
                .ReportViewer1.LocalReport.ReportPath = "C:\" + nombreRpt
                .ReportViewer1.Refresh()
                .MdiParent = Form1
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar el reporte")
        End Try
    End Sub
End Module
