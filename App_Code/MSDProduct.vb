'Imports Microsoft.VisualBasic
Imports System.Xml
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Text
Imports MSD.CMS.SharedFunctions
Imports MSD.CMS.messagelogger


Public Class MSDProduct

    Private m_partnumber As String
    Private m_productname As String
    Private m_description As String
    Private m_shortdescription As String
    Private m_bulletattributes As String
    Private m_specifications As String
    Private m_techtips As String
    Private m_mvpprice As String
    Private m_graphic As String
    Private m_productimage As String
    Private m_instructions As String
    Private m_carbapproved As String
    Private m_metaobdiilegal As String
    Private m_metashopatronbuylink As String
    Private m_contenttitle As String
    Private m_productimage_alt_text As String
    Private m_graphic_alt_text As String
    Private m_instructionstitle As String
    Private m_instructionshref As String
    Private m_folderid As String
    Private m_taxonomyid As String
    Private m_replacementparts As String
    Private m_requiredcomponents As String
    Private m_accessories As String
    Private m_uploadedfilespath As String
    Private m_uploadedimagespath As String
    Private m_contentid As String


    Public Sub New()
        'Clears values
        m_contentid = String.Empty
        m_partnumber = String.Empty
        m_productname = String.Empty
        m_description = String.Empty
        m_shortdescription = String.Empty
        m_bulletattributes = String.Empty
        m_specifications = String.Empty
        m_techtips = String.Empty
        m_mvpprice = String.Empty
        m_graphic = String.Empty
        m_productimage = String.Empty
        m_instructions = String.Empty
        m_instructionshref = String.Empty
        m_instructionstitle = String.Empty
        m_carbapproved = String.Empty
        m_metaobdiilegal = String.Empty
        m_metashopatronbuylink = String.Empty
        m_contenttitle = String.Empty
        m_graphic_alt_text = String.Empty
        m_productimage_alt_text = String.Empty
        m_taxonomyid = String.Empty
        m_folderid = String.Empty
        m_accessories = String.Empty
        m_replacementparts = String.Empty
        m_requiredcomponents = String.Empty
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

                '.PartNumber = oXMLNode.SelectSingleNode("partnumber").InnerText
                '.Name = oXMLNode.SelectSingleNode("productname").InnerText
                '.ContentTitle = oXMLNode.SelectSingleNode("productname").InnerText
                '.Description = oXMLNode.SelectSingleNode("description").InnerXml
                '.ShortDescription = oXMLNode.SelectSingleNode("shortdescription").InnerXml
                '.BulletAttributes = oXMLNode.SelectSingleNode("bulletsattributes").InnerXml
                '.Specifications = oXMLNode.SelectSingleNode("specifications").InnerXml
                '.TechTips = oXMLNode.SelectSingleNode("techtips").InnerXml
                '.MVPPrice = oXMLNode.SelectSingleNode("mvpprice").InnerText
                '.Graphic = CType(oXMLNode.SelectSingleNode("graphic/img"), XmlElement).GetAttribute("src")
                '.GraphicAltText = CType(oXMLNode.SelectSingleNode("graphic/img"), XmlElement).GetAttribute("alt")
                '.Image = CType(oXMLNode.SelectSingleNode("productimage/img"), XmlElement).GetAttribute("src")
                '.ImageAltText = CType(oXMLNode.SelectSingleNode("productimage/img"), XmlElement).GetAttribute("alt")
                '.Instructions = oXMLNode.SelectSingleNode("instructions/a").InnerText
                '.InstructionsTitle = CType(oXMLNode.SelectSingleNode("instructions/a"), XmlElement).GetAttribute("title")
                '.InstructionsHref = CType(oXMLNode.SelectSingleNode("instructions/a"), XmlElement).GetAttribute("href")

                '.IsCarbApproved = oXMLNode.SelectSingleNode("carbapproved").InnerText
                '.IsOBDIILegal = oXMLNode.SelectSingleNode("meta-obdiilegal").InnerText
                '.ShopatronBuyLink = oXMLNode.SelectSingleNode("meta-shopatronbuylink").InnerText
                '.FolderID = oXMLNode.SelectSingleNode("folderid").InnerText
                '.TaxonomyID = oXMLNode.SelectSingleNode("taxonomyid").InnerText
                '.ReplacementParts = oXMLNode.SelectSingleNode("meta-replacementparts").InnerText
                '.RequiredComponents = oXMLNode.SelectSingleNode("meta-requiredcomponents").InnerText
                '.Accessories = oXMLNode.SelectSingleNode("meta-accessories").InnerText

                .PartNumber = MySelectSingleXMLNode(oXMLNode, "partnumber").InnerText
                .Name = MySelectSingleXMLNode(oXMLNode, "productname").InnerText
                .ContentTitle = MySelectSingleXMLNode(oXMLNode, "productname").InnerText
                .Description = MySelectSingleXMLNode(oXMLNode, "description").InnerXml
                .ShortDescription = MySelectSingleXMLNode(oXMLNode, "shortdescription").InnerXml
                .BulletAttributes = MakeBullets(MySelectSingleXMLNode(oXMLNode, "bulletsattributes").InnerXml)
                .Specifications = MySelectSingleXMLNode(oXMLNode, "specifications").InnerXml
                .TechTips = MySelectSingleXMLNode(oXMLNode, "techtips").InnerXml
                .MVPPrice = MySelectSingleXMLNode(oXMLNode, "mvpprice").InnerText
                .Graphic = CType(MySelectSingleXMLNode(oXMLNode, "graphic/img"), XmlElement).GetAttribute("src")
                .GraphicAltText = CType(MySelectSingleXMLNode(oXMLNode, "graphic/img"), XmlElement).GetAttribute("alt")
                .Image = CType(MySelectSingleXMLNode(oXMLNode, "productimage/img"), XmlElement).GetAttribute("src")
                .ImageAltText = CType(MySelectSingleXMLNode(oXMLNode, "productimage/img"), XmlElement).GetAttribute("alt")
                .Instructions = MySelectSingleXMLNode(oXMLNode, "instructions/a").InnerText
                .InstructionsTitle = CType(MySelectSingleXMLNode(oXMLNode, "instructions/a"), XmlElement).GetAttribute("title")
                .InstructionsHref = CType(MySelectSingleXMLNode(oXMLNode, "instructions/a"), XmlElement).GetAttribute("href")

                .IsCarbApproved = MySelectSingleXMLNode(oXMLNode, "carbapproved").InnerText
                .IsOBDIILegal = MySelectSingleXMLNode(oXMLNode, "meta-obdiilegal").InnerText
                .ShopatronBuyLink = MySelectSingleXMLNode(oXMLNode, "meta-shopatronbuylink").InnerText
                .FolderID = MySelectSingleXMLNode(oXMLNode, "folderid").InnerText
                .TaxonomyID = MySelectSingleXMLNode(oXMLNode, "taxonomyid").InnerText
                .ReplacementParts = MySelectSingleXMLNode(oXMLNode, "meta-replacementparts").InnerText
                .RequiredComponents = MySelectSingleXMLNode(oXMLNode, "meta-requiredcomponents").InnerText
                .Accessories = MySelectSingleXMLNode(oXMLNode, "meta-accessories").InnerText

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
        m_mvpprice = String.Empty
        m_graphic = String.Empty
        m_productimage = String.Empty
        m_instructions = String.Empty
        m_instructionshref = String.Empty
        m_instructionstitle = String.Empty
        m_carbapproved = String.Empty
        m_metaobdiilegal = String.Empty
        m_metashopatronbuylink = String.Empty
        m_contenttitle = String.Empty
        m_graphic_alt_text = String.Empty
        m_productimage_alt_text = String.Empty
        m_taxonomyid = String.Empty
        m_folderid = String.Empty
        m_accessories = String.Empty
        m_replacementparts = String.Empty
        m_requiredcomponents = String.Empty
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


    Public Property MVPPrice() As String
        Get
            Return m_mvpprice
        End Get
        Set(ByVal value As String)
            m_mvpprice = value
        End Set
    End Property

    Public Property Graphic() As String
        Get
            Return m_graphic
        End Get
        Set(ByVal value As String)
            m_graphic = value
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

    Public Property IsCarbApproved() As String
        Get
            Return m_carbapproved
        End Get
        Set(ByVal value As String)
            m_carbapproved = value
        End Set
    End Property

    Public Property IsOBDIILegal() As String
        Get
            Return m_metaobdiilegal
        End Get
        Set(ByVal value As String)
            m_metaobdiilegal = value
        End Set
    End Property

    Public Property ShopatronBuyLink() As String
        Get
            Return m_metashopatronbuylink
        End Get
        Set(ByVal value As String)
            m_metashopatronbuylink = value
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

    Public Property GraphicAltText() As String
        Get
            Return m_graphic_alt_text
        End Get
        Set(ByVal value As String)
            m_graphic_alt_text = value
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
    Public Property Accessories() As String
        Get
            Return m_accessories
        End Get
        Set(ByVal value As String)
            m_accessories = value
        End Set
    End Property

    Public Property RequiredComponents() As String
        Get
            Return m_requiredcomponents
        End Get
        Set(ByVal value As String)
            m_requiredcomponents = value
        End Set
    End Property

    Public Property ReplacementParts() As String
        Get
            Return m_replacementparts
        End Get
        Set(ByVal value As String)
            m_replacementparts = value
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
