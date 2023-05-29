Imports System.Data.SqlClient
Public Class MonitorDao
    Private strConn As String = My.Settings.StrConexion

    Public Function GuardarRegistro(ByVal monitor As MonitorEntity) As Boolean
        Dim flag As Boolean = False
        Try
            Dim tsql As String = "INSERT INTO Monitor(idUca, primerNombre, segundoNombre, primerApellido, segundoApellido, fechaNac, idCiudad, direccion, email, idMateria, observaciones) values(@idUca, @primerN, @segundoN, @primerA, @segundoA, @fechaNac, @idCiudad, @direccion, @email, @idMateria, @observaciones)"
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Parameters.AddWithValue("@idUca", monitor.IdUCA)
            cmd.Parameters.AddWithValue("@primerN", monitor.PrimerNombre)
            cmd.Parameters.AddWithValue("@segundoN", monitor.SegundoNombre)
            cmd.Parameters.AddWithValue("@primerA", monitor.PrimerApellido)
            cmd.Parameters.AddWithValue("@segundoA", monitor.SegundoApellido)
            cmd.Parameters.AddWithValue("@fechaNac", monitor.FechaNac)
            cmd.Parameters.AddWithValue("@idCiudad", monitor.Ciudad.Id)
            cmd.Parameters.AddWithValue("@direccion", monitor.Direccion)
            cmd.Parameters.AddWithValue("@email", monitor.Email)
            cmd.Parameters.AddWithValue("@idMateria", monitor.Materia.Id)
            cmd.Parameters.AddWithValue("@observaciones", monitor.Observaciones)
            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                flag = True
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            flag = False
        End Try
        Return flag
    End Function

    Public Function EditarRegistro(ByVal monitor As MonitorEntity) As Boolean
        Dim flag As Boolean = False
        Try
            Dim tsql As String = "UPDATE Monitor set idUca = @idUca, primerNombres =@primerN, segundoNombre = @segundoN, primerApellido = @primerA, segundoApellido= @segundoA,  fechaNac = @fechaNac, idCiudad = @idCiudad, direccion = @direccion, email = @email, idMateria = @idMateria, observaciones = @observaciones WHERE id = @id"
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Parameters.AddWithValue("@idUca", monitor.IdUCA)
            cmd.Parameters.AddWithValue("@primerN", monitor.PrimerNombre)
            cmd.Parameters.AddWithValue("@segundoN", monitor.SegundoNombre)
            cmd.Parameters.AddWithValue("@primerA", monitor.PrimerApellido)
            cmd.Parameters.AddWithValue("@segundoA", monitor.SegundoApellido)
            cmd.Parameters.AddWithValue("@fechaNac", monitor.FechaNac)
            cmd.Parameters.AddWithValue("@idCiudad", monitor.Ciudad.Id)
            cmd.Parameters.AddWithValue("@direccion", monitor.Direccion)
            cmd.Parameters.AddWithValue("@email", monitor.Email)
            cmd.Parameters.AddWithValue("@idMateria", monitor.Materia.Id)
            cmd.Parameters.AddWithValue("@observaciones", monitor.Observaciones)
            cmd.Parameters.AddWithValue("@id", monitor.Id)
            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                flag = True
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Public Function EliminarRegistro(ByVal id As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            Dim tsql As String = "DELETE FROM Monitor WHERE id = @id"
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                flag = True
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT Monitor.id, Monitor.idUca, Monitor.primerNombre, Monitor.segundoNombre, Monitor.primerApellido, Monitor.segundoApellido, Monitor.fechaNac, Monitor.idCiudad, Ciudad.nombre as 'nombreCiudad', Monitor.direccion, Monitor.email, Monitor.idMateria, Materia.nombre AS 'nombreMateria', Monitor.observaciones, Monitor.estado FROM Monitor INNER JOIN Materia ON Monitor.idMateria = Materia.id INNER JOIN Ciudad ON Ciudad.id = Monitor.idCiudad AND Materia.id = Monitor.idMateria"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function

    Public Function ListarMonitores() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT Monitor.idUca, Monitor.primerNombre + N' ' + Monitor.segundoNombre + N' ' + Monitor.primerApellido + N' ' + Monitor.segundoApellido as N'Monitor', convert(varchar(10), Monitor.fechaNac, 103) as N'FechaNac', Ciudad.nombre AS Ciudad, Monitor.email, Materia.nombre AS Materia FROM Monitor INNER JOIN Ciudad ON Ciudad.id = Monitor.idCiudad INNER JOIN Materia ON Materia.id = Monitor.idMateria AND Materia.id = Monitor.idMateria"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function
End Class
