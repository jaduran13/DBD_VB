Public Class MonitorEntity
    Private _id As Integer
    Private _idUCA As String
    Private _primerNombre As String
    Private _segundoNombre As String
    Private _primerApellido As String
    Private _segundoApellido As String
    Private _fechaNac As Date
    Private _ciudad As New CiudadEntity
    Private _direccion As String
    Private _email As String
    Private _materia As New MateriaEntity
    Private _observaciones As String

    Public Sub New()

    End Sub

    Public Sub New(id As Integer, idUCA As String, primerNombre As String, segundoNombre As String, primerApellido As String, segundoApellido As String, fechaNac As Date, ciudad As CiudadEntity, direccion As String, email As String, materia As MateriaEntity, observaciones As String)
        Me.Id = id
        Me.IdUCA = idUCA
        Me.PrimerNombre = primerNombre
        Me.SegundoNombre = segundoNombre
        Me.PrimerApellido = primerApellido
        Me.SegundoApellido = segundoApellido
        Me.FechaNac = fechaNac
        Me.Ciudad = ciudad
        Me.Direccion = direccion
        Me.Email = email
        Me.Materia = materia
        Me.Observaciones = observaciones
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property IdUCA As String
        Get
            Return _idUCA
        End Get
        Set(value As String)
            _idUCA = value
        End Set
    End Property

    Public Property PrimerNombre As String
        Get
            Return _primerNombre
        End Get
        Set(value As String)
            _primerNombre = value
        End Set
    End Property

    Public Property SegundoNombre As String
        Get
            Return _segundoNombre
        End Get
        Set(value As String)
            _segundoNombre = value
        End Set
    End Property

    Public Property PrimerApellido As String
        Get
            Return _primerApellido
        End Get
        Set(value As String)
            _primerApellido = value
        End Set
    End Property

    Public Property SegundoApellido As String
        Get
            Return _segundoApellido
        End Get
        Set(value As String)
            _segundoApellido = value
        End Set
    End Property

    Public Property FechaNac As Date
        Get
            Return _fechaNac
        End Get
        Set(value As Date)
            _fechaNac = value
        End Set
    End Property

    Public Property Ciudad As CiudadEntity
        Get
            Return _ciudad
        End Get
        Set(value As CiudadEntity)
            _ciudad = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property Materia As MateriaEntity
        Get
            Return _materia
        End Get
        Set(value As MateriaEntity)
            _materia = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Return _observaciones
        End Get
        Set(value As String)
            _observaciones = value
        End Set
    End Property
End Class
