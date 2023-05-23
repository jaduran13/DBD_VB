Imports System.Data.SqlClient

Public Class CiudadDao
    Dim strConn As String = My.Settings.StrConexion

    Public Function AgregarRegistro(ByVal ciudad As CiudadEntity) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "Insert into Ciudad(nombre) values(@nombre)"
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre)
            cmd.Connection = conn
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery Then
                resp = True
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            resp = False
        End Try
        Return resp
    End Function

    Public Function EditarRegistro(ByVal ciudad As CiudadEntity) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "update Ciudad set nombre = @nombre, estado = @estado where id = @id"
            Dim conn As New SqlConnection(strConn)
            conn.Open()
            Dim cmd As New SqlCommand(tsql, conn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@nombre", ciudad.Nombre)
            cmd.Parameters.AddWithValue("@estado", ciudad.Estado)
            cmd.Parameters.AddWithValue("@id", ciudad.Id)
            If (cmd.ExecuteNonQuery <> 0) Then
                resp = True
            End If
            conn.Close()
        Catch ex As Exception
            resp = False
        End Try
        Return resp
    End Function

    Public Function EliminarRegistro(ByVal id As Integer) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "delete from Ciudad  where id = @id"
            Dim conn As New SqlConnection(strConn)
            conn.Open()
            Dim cmd As New SqlCommand(tsql, conn)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@id", id)
            If (cmd.ExecuteNonQuery <> 0) Then
                resp = True
            End If
            conn.Close()
        Catch ex As Exception
            resp = False
        End Try
        Return resp
    End Function

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "select * from Ciudad"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception

        End Try
        Return ds
    End Function

    Public Function BuscarRegistro(ByVal id As Integer) As CiudadEntity
        Dim ciudad As New CiudadEntity
        Try
            Dim tsql As String = "select * from Ciudad where id = @id"
            Dim conn As New SqlConnection(strConn)
            Dim tbl As New DataTable
            Dim da As New SqlDataAdapter(tsql, conn)
            da.SelectCommand.Parameters.AddWithValue("@id", id)
            da.Fill(tbl)
            If tbl.Rows.Count > 0 Then
                ciudad.Id = tbl.Rows(0).Item("id")
                ciudad.Nombre = tbl.Rows(0).Item("nombre")
                ciudad.Estado = tbl.Rows(0).Item("estado")
            End If
        Catch ex As Exception

        End Try
        Return ciudad
    End Function
End Class
