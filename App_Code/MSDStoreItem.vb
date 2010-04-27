'Imports Microsoft.VisualBasic
Imports System.Xml
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Text
Imports MSD.CMS.SharedFunctions
Imports MSD.CMS.MessageLogger


Public Class MSDStoreItem

    Private m_partnumber As String
    Private m_productname As String
    Private m_productprice As String
    Private m_description As String
    Private m_shortdescription As String
    Private m_bulletattributes As String
    Private m_specifications As String
    Private m_techtips As String
    Private m_instructions As String
    Private m_contenttitle As String
    Private m_productimage As String
    Private m_productimage_alt_text As String
    Private m_instructionstitle As String
    Private m_instructionshref As String
    Private m_folderid As String
    Private m_taxonomyid As String
    Private m_uploadedfilespath As String
    Private m_uploadedimagespath As String
    Private m_contentid As String


    Public Sub New()
        'Clears values
        m_contentid = String.Empty
        m_partnumber = String.Empty
        m_productname = String.Empty
        m_productprice = String.Empty
        m_description = String.Empty
        m_shortdescription = String.Empty
        m_bulletattributes = String.Empty
        m_specifications = String.Empty
        m_techtips = String.Empty
        m_productimage = String.Empty
        m_instructions = String.Empty
        m_instructionshref = String.Empty
        m_instructionstitle = String.Empty
        m_contenttitle = String.Empty
        m_productimage_alt_text = String.Empty
        m_taxonomyid = String.Empty
        m_folderid = String.Empty
        m_uploadedfilespath = String.Empty
        m_uploadedimagespath = String.Empty

    End Sub
    Private Function MakeBullets(ByVal FlatText As String) As String
        Dim sb As New StringBuilder
        Dim ListItem As String
        Dim arrListItems As String()

        'arrListItems = Split(FlatText, ";")
        arrListItems = FlatText.Split(";")
        sb.Append("<ul>")
        For Each ListItem In arrListItems
            sb.Append("<li>")
            sb.Append(ListItem)
            sb.Append("</li>")
        Next
        sb.Append("</ul>")

        Return (sb.ToString)
    End Function
    Public Function MySelectSingleXMLNode(ByVal oXMLNode As XmlNode, ByVal NodeName As String) As XmlNode
        Dim oXMLTempNode As XmlNode
        Dim oXMLDoc As New XmlDocument
        'Dim messLogger As New MessageLogger(HttpContext.Current.Server.MapPath("data\"))


        Try
            oXMLTempNode = oXMLNode.SelectSingleNode(NodeName)

            If oXMLTempNode Is Nothing Then
                oXMLTempNode = oXMLDoc.CreateNode(XmlNodeType.Element, "x", "y", "z")
                oXMLTempNode.InnerText = String.Empty
            End If

        Catch ex As System.Exception
            oXMLTempNode = oXMLDoc.CreateNode(XmlNodeType.Element, "x", "y", "z")
            oXMLTempNode.InnerText = String.Empty
            'messLogger.LogMessage("Exception when reading " & NodeName)
        End Try

        Return oXMLTempNode
    End Function
    Public Sub LoadFromXML(ByVal oXMLNode As XmlNode)
        Try
            With Me

                .PartNumber = MySelectSingleXMLNode(oXMLNode, "partnumber").InnerText
                .Name = MySelectSingleXMLNode(oXMLNode, "productname").InnerText
                .ContentTitle = MySelectSingleXMLNode(oXMLNode, "productname").InnerText
                .Description = MySelectSingleXMLNode(oXMLNode, "description").InnerXml
                .ShortDescription = MySelectSingleXMLNode(oXMLNode, "shortdescription").InnerXml
                .BulletAttributes = MakeBullets(MySelectSingleXMLNode(oXMLNode, "bulletsattributes").InnerXml)
                .Specifications = MySelectSingleXMLNode(oXMLNode, "specifications").InnerXml
                .TechTips = MySelectSingleXMLNode(oXMLNode, "techtips").InnerXml
                .ProductPrice = MySelectSingleXMLNode(oXMLNode, "productprice").InnerText
                .Image = CType(MySelectSingleXMLNode(oXMLNode, "productimage/img"), XmlElement).GetAttribute("src")
                .ImageAltText = CType(MySelectSingleXMLNode(oXMLNode, "productimage/img"), XmlElement).GetAttribute("alt")
                .Instructions = MySelectSingleXMLNode(oXMLNode, "instructions/a").InnerText
                .InstructionsTitle = CType(MySelectSingleXMLNode(oXMLNode, "instructions/a"), XmlElement).GetAttribute("title")
                .InstructionsHref = CType(MySelectSingleXMLNode(oXMLNode, "instructions/a"), XmlElement).GetAttribute("href")
                .FolderID = MySelectSingleXMLNode(oXMLNode, "folderid").InnerText
                .TaxonomyID = MySelectSingleXMLNode(oXMLNode, "taxonomyid").InnerText

                'Connect to LookupTable and retrieve ContentID
                Dim dbcommand As DbCommand
                Dim dbMSDAPI As Database = DatabaseFactory.CreateDatabase("Ektron.DbConnection")
                Dim sqlString As String

                sqlString = "SELECT ContentID FROM msd_content_lookup WHERE partnumber = '" & .PartNumber & "'"
                dbcommand = dbMSDAPI.GetSqlStringCommand(sqlString)

                .ContentID = dbMSDAPI.ExecuteScalar(dbcommand)

            End With
        Catch ex As System.NullReferenceException
            Throw (ex)
        End Try

    End Sub
    Public Sub Clear()
        'Clears values
        m_contentid = String.Empty
        m_partnumber = String.Empty
        m_productname = String.Empty
        m_description = String.Empty
        m_shortdescription = String.Empty
        m_bulletattributes = String.Empty
        m_specifications = String.Empty
        m_techtips = String.Empty
        m_productimage = String.Empty
        m_instructions = String.Empty
        m_instructionshref = String.Empty
        m_instructionstitle = String.Empty
        m_contenttitle = String.Empty
        m_productimage_alt_text = String.Empty
        m_taxonomyid = String.Empty
        m_folderid = String.Empty
        m_uploadedfilespath = String.Empty
        m_uploadedimagespath = String.Empty
    End Sub
    Public Property ContentID() As Integer
        Get
            Return m_contentid
        End Get
        Set(ByVal value As Integer)
            m_contentid = value
        End Set
    End Property

    Public Property PartNumber() As String
        Get
            Return m_partnumber
        End Get
        Set(ByVal value As String)
            m_partnumber = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return m_productname
        End Get
        Set(ByVal value As String)
            m_productname = value
        End Set
    End Property

    Public Property ProductPrice() As String
        Get
            Return m_productprice
        End Get
        Set(ByVal value As String)
            m_productprice = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return m_description
        End Get
        Set(ByVal value As String)
            m_description = value
        End Set
    End Property
    Public Property TechTips() As String
        Get
            Return m_techtips
        End Get
        Set(ByVal value As String)
            m_techtips = value
        End Set
    End Property


    Public Property Specifications() As String
        Get
            Return m_specifications
        End Get
        Set(ByVal value As String)
            m_specifications = value
        End Set
    End Property

    Public Property BulletAttributes() As String
        Get
            Return m_bulletattributes
        End Get
        Set(ByVal value As String)
            m_bulletattributes = value
        End Set
    End Property



    Public Property ShortDescription() As String
        Get
            Return m_shortdescription
        End Get
        Set(ByVal value As String)
            m_shortdescription = value
        End Set
    End Property

    Public Property Image() As String
        Get
            Return m_productimage
        End Get
        Set(ByVal value As String)
            m_productimage = value
        End Set
    End Property

    Public Property Instructions() As String
        Get
            Return m_instructions
        End Get
        Set(ByVal value As String)
            m_instructions = value
        End Set
    End Property

    Public Property ContentTitle() As String
        Get
            Return m_contenttitle
        End Get
        Set(ByVal value As String)
            m_contenttitle = value
        End Set
    End Property
    Public Property ImageAltText() As String
        Get
            Return m_productimage_alt_text
        End Get
        Set(ByVal value As String)
            m_productimage_alt_text = value
        End Set
    End Property

    Public Property InstructionsTitle() As String
        Get
            Return m_instructionstitle
        End Get
        Set(ByVal value As String)
            m_instructionstitle = value
        End Set
    End Property
    Public Property InstructionsHref() As String
        Get
            Return m_instructionshref
        End Get
        Set(ByVal value As String)
            m_instructionshref = value
        End Set
    End Property
    
    Public Property TaxonomyID() As String
        Get
            Return m_taxonomyid
        End Get
        Set(ByVal value As String)
            m_taxonomyid = value
        End Set
    End Property
    Public Property FolderID() As String
        Get
            Return m_folderid
        End Get
        Set(ByVal value As String)
            m_folderid = value
        End Set
    End Property
    Public Property UploadedImagesPath() As String
        Get
            Return m_uploadedimagespath
        End Get
        Set(ByVal value As String)
            m_uploadedimagespath = value
        End Set
    End Property

    Public Property UploadedFilesPath() As String
        Get
            Return m_uploadedfilespath
        End Get
        Set(ByVal value As String)
            m_uploadedfilespath = value
        End Set
    End Property


End Class
