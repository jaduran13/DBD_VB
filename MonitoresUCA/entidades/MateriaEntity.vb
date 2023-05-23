Public Class MateriaEntity
    Private _id As Integer
    Private _nombre As String
    Private _estado As Boolean

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Estado As Boolean
        Get
            Return _estado
        End Get
        Set(value As Boolean)
            _estado = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(id As Integer, nombre As String, estado As Boolean)
        Me.Id = id
        Me.Nombre = nombre
        Me.Estado = estado
    End Sub
End Class
