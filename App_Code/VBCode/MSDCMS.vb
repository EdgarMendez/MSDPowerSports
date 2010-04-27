Imports System.Xml
Imports System.Text
Imports System

Namespace MSD.CMS
    Public Class SharedFunctions

        Public Shared Function GetBannerByFolderID(ByVal FolderID As Integer) As Integer
            'Match content blocks for each banner         
            Const ACCESSORIES_BANNER As Integer = 11915
            Const APS_BANNER As Integer = 11923
            Const APPAREL_BANNER As Integer = 11927
            Const COILS_BANNER As Integer = 11939
            Const CRANKTRIGGERS_BANNER As Integer = 11943
            Const DISTRIBUTORS_BANNER As Integer = 11911
            Const ELECTRONICS_BANNER As Integer = 11919
            Const IGNITIONS_BANNER As Integer = 11857
            Const MARINE_BANNER As Integer = 11935
            Const RPM_BANNER As Integer = 11947
            Const SPARKPLUGWIRES_BANNER As Integer = 11931
            Const TOOLS_BANNER As Integer = 11951

            Const ACCESSORIES_FOLDERID As Integer = 103
            Const APS_FOLDERID As Integer = 97
            Const APPAREL_FOLDERID As Integer = 117
            Const COILS_FOLDERID As Integer = 32
            Const CRANKTRIGGERS_FOLDERID As Integer = 99
            Const DISTRIBUTORS_FOLDERID As Integer = 34
            Const ELECTRONICS_FOLDERID As Integer = 105
            Const IGNITIONS_FOLDERID As Integer = 30
            Const MARINE_FOLDERID As Integer = 111
            Const RPM_FOLDERID As Integer = 115
            Const SPARKPLUGWIRES_FOLDERID As Integer = 36
            Const TOOLS_FOLDERID As Integer = 113

            Select Case FolderID
                Case ACCESSORIES_FOLDERID
                    Return (ACCESSORIES_BANNER)
                Case APS_FOLDERID
                    Return (APS_BANNER)
                Case APPAREL_FOLDERID
                    Return (APPAREL_BANNER)
                Case COILS_FOLDERID
                    Return (COILS_BANNER)
                Case CRANKTRIGGERS_FOLDERID
                    Return (CRANKTRIGGERS_BANNER)
                Case DISTRIBUTORS_FOLDERID
                    Return (DISTRIBUTORS_BANNER)
                Case ELECTRONICS_FOLDERID
                    Return (ELECTRONICS_BANNER)
                Case IGNITIONS_FOLDERID
                    Return (IGNITIONS_BANNER)
                Case MARINE_FOLDERID
                    Return (MARINE_BANNER)
                Case RPM_FOLDERID
                    Return (RPM_BANNER)
                Case SPARKPLUGWIRES_FOLDERID
                    Return (SPARKPLUGWIRES_BANNER)
                Case TOOLS_FOLDERID
                    Return (TOOLS_BANNER)
                Case Else
                    Return (IGNITIONS_BANNER)
            End Select
        End Function

        Public Shared Function GetContentIntroByTaxID(ByVal TaxID As Integer) As Integer
            'Match content blocks for each banner         
            Const ACCESSORIES_INTRO As Integer = 12313
            Const APS_INTRO As Integer = 12221
            Const APPAREL_INTRO As Integer = 12315
            Const COILS_INTRO As Integer = 12317
            Const CRANKTRIGGERS_INTRO As Integer = 12223
            Const DISTRIBUTORS_INTRO As Integer = 12219
            Const ELECTRONICS_INTRO As Integer = 12319
            Const IGNITIONS_INTRO As Integer = 12215
            Const MARINE_INTRO As Integer = 12225
            Const RPM_INTRO As Integer = 12227
            Const SPARKPLUGWIRES_INTRO As Integer = 12323
            Const SPORTCOMPACT_INTRO As Integer = 12321
            Const TOOLS_INTRO As Integer = 12273

            Const ACCESSORIES_TAXID As Integer = 256
            Const APS_TAXID As Integer = 301
            Const APPAREL_TAXID As Integer = 277
            Const COILS_TAXID As Integer = 6
            Const CRANKTRIGGERS_TAXID As Integer = 32
            Const DISTRIBUTORS_TAXID As Integer = 8
            Const ELECTRONICS_TAXID As Integer = 196
            Const IGNITIONS_TAXID As Integer = 4
            Const MARINE_TAXID As Integer = 40
            Const RPM_TAXID As Integer = 38
            Const SPARKPLUGWIRES_TAXID As Integer = 10
            Const SPORTCOMPACT_TAXID As Integer = 34
            Const TOOLS_TAXID As Integer = 263

            Select Case TaxID
                Case ACCESSORIES_TAXID
                    Return (ACCESSORIES_INTRO)
                Case APS_TAXID
                    Return (APS_INTRO)
                Case APPAREL_TAXID
                    Return (APPAREL_INTRO)
                Case COILS_TAXID
                    Return (COILS_INTRO)
                Case CRANKTRIGGERS_TAXID
                    Return (CRANKTRIGGERS_INTRO)
                Case DISTRIBUTORS_TAXID
                    Return (DISTRIBUTORS_INTRO)
                Case ELECTRONICS_TAXID
                    Return (ELECTRONICS_INTRO)
                Case IGNITIONS_TAXID
                    Return (IGNITIONS_INTRO)
                Case MARINE_TAXID
                    Return (MARINE_INTRO)
                Case RPM_TAXID
                    Return (RPM_INTRO)
                Case SPARKPLUGWIRES_TAXID
                    Return (SPARKPLUGWIRES_INTRO)
                Case SPORTCOMPACT_TAXID
                    Return (SPORTCOMPACT_INTRO)
                Case TOOLS_TAXID
                    Return (TOOLS_INTRO)
                Case Else
                    Return (IGNITIONS_INTRO)
            End Select
        End Function


        Public Shared Function generateHtmlByTaxonomyID(ByVal taxId As Integer, ByVal thisPage As System.Web.UI.Page) As String
            Dim taxControl As New Ektron.Cms.Controls.Directory
            taxControl.TaxonomyId = taxId
            taxControl.Page = thisPage
            taxControl.TaxonomyDepth = 4
            taxControl.Fill()
            Dim taxData As Ektron.Cms.TaxonomyData = taxControl.TaxonomyTreeData
            Dim taxItem As New Ektron.Cms.TaxonomyItemData
            Dim idString As String = String.Empty
            Dim token As Ektron.Cms.Common.ContentBase
            Dim sb As New StringBuilder
            Dim i As Integer

            Try
                For Each taxItem In taxData.TaxonomyItems
                    idString &= taxItem.TaxonomyItemId & ","
                Next

                If taxData.TaxonomyHasChildren Then
                    For i = 0 To taxData.Taxonomy.Length - 1
                        For Each taxItem In taxData.Taxonomy(i).TaxonomyItems
                            idString &= taxItem.TaxonomyItemId & ","
                        Next
                    Next
                End If

                If idString.Length > 0 Then
                    idString = idString.Substring(0, idString.Length - 1)
                    Dim contentlist As New Ektron.Cms.Controls.ContentList
                    contentlist.ContentIds = idString
                    contentlist.ID = "MSDContentList"
                    contentlist.GetHtml = True
                    contentlist.DisplayXslt = "ecmNavigation"
                    contentlist.Page = thisPage
                    contentlist.Fill()

                    Dim QuickLink As String = String.Empty
                    Dim htmlpreview As String = String.Empty
                    For Each token In contentlist.EkItems
                        'Only Content items will be displayed (not files)
                        If (token.ContentType = Ektron.Cms.Common.EkEnumeration.CMSContentType.Content) Or (token.ContentType = Ektron.Cms.Common.EkEnumeration.CMSContentType.CatalogEntry) Then
                            'If (token.ContentType = Ektron.Cms.Common.EkEnumeration.CMSContentType.CatalogEntry) Then
                            QuickLink = "<QuickLink>" & token.QuickLink & "</QuickLink>"
                            htmlpreview = token.Html

                            htmlpreview = htmlpreview.Insert(htmlpreview.LastIndexOf("<"), QuickLink)

                            If (thisPage.Request("t") = "app") Then
                                sb.AppendLine(buildApparelPreview(htmlpreview))
                            Else
                                sb.AppendLine(buildProductPreview(htmlpreview))
                            End If

                        End If
                    Next

                    Return (sb.ToString)

                Else
                    Return ("No items")
                End If
            Catch e As System.Exception
                thisPage.Response.Write("error:" & e.Message)
                Return ("No items")
            End Try
        End Function
        Public Shared Function replaceThumbnailImage(ByVal XMLString As String) As String
            'Double check this function
            Dim oXml As New XmlDocument
            Dim srcImageURL As String
            Dim srcThumb As String
            Dim srcNewURL As String
            Dim parts As String()

            oXml.LoadXml(XMLString)

            srcImageURL = oXml.DocumentElement.GetAttribute("src")
            oXml.DocumentElement.SetAttribute("border", "0")
            parts = srcImageURL.Split("/")
            srcThumb = "thumb_" & parts(parts.Length - 1)

            srcNewURL = srcImageURL.Replace(parts(parts.Length - 1), srcThumb)

            oXml.DocumentElement.SetAttribute("src", srcNewURL)

            Return (oXml.OuterXml)

        End Function

        Public Shared Function generateThumbnailImage(ByVal XMLString As String) As String
            Dim oXml As New XmlDocument
            Dim srcImageURL As String
            Dim srcThumb As String
            Dim srcNewURL As String
            Dim parts As String()

            oXml.LoadXml(XMLString)
            srcImageURL = oXml.DocumentElement.GetAttribute("href")
            parts = srcImageURL.Split("/")
            srcThumb = "thumb_" & parts(parts.Length - 1)

            srcNewURL = srcImageURL.Replace(parts(parts.Length - 1), srcThumb)

            Return (srcNewURL)

        End Function
        'Build the preview of the product using the XML info
        Public Shared Function buildProductPreview(ByVal XMLMarkup As String) As String
            Dim sb As New StringBuilder
            Dim xmlDoc As New XmlDocument
            Dim sDescription As String

            xmlDoc.LoadXml(XMLMarkup)
            'sb.Append("<XMLHERE>" & XMLMarkup & "</XMLHERE>")
            'sb.Append(xmlDoc.InnerXml.ToString)

            sDescription = getXMLNodeString(xmlDoc, "/root/product/shortdescription")

            sb.AppendLine("<!-- Product preview -->")
            sb.AppendLine("<div class=""IndividualBox"">")
            sb.AppendLine("<div class=""PImageBox""><div class=""PImage"" style=""background-color:#FFFFFF;"">")
            'sb.Append("thumb_")
            'sb.AppendLine(replaceThumbnailImage(getXMLNodeString(xmlDoc, "/root/product/graphic")))
            sb.AppendLine("<a href=""" & getXMLNodeString(xmlDoc, "/root/QuickLink") & """>")
            sb.AppendLine(replaceThumbnailImage(getXMLNodeString(xmlDoc, "/root/product/productimage")))
            sb.AppendLine("</a>")
            'sb.Append(getXMLNodeString(xmlDoc, "/root/product/graphic"))
            sb.AppendLine("</div></div>")

            sb.AppendLine("<div class=""PInfoBox""><div class=""PHeader"">")
            sb.AppendLine("<a href=""" & getXMLNodeString(xmlDoc, "/root/QuickLink") & """>")
            sb.AppendLine(getXMLNodeString(xmlDoc, "/root/product/productname"))
            sb.AppendLine("</a>")
            sb.AppendLine("</div>")

            sb.AppendLine("<div class=""PNumber"">")
            sb.Append("Part number: ")
            sb.AppendLine(getXMLNodeString(xmlDoc, "/root/product/partnumber"))
            sb.AppendLine("</div>")

            sb.AppendLine("<div class=""Description"">")

            If (sDescription.Length > 150) Then
                sb.AppendLine(sDescription.Substring(0, 150) & " (...)")
            Else
                sb.AppendLine(sDescription)
            End If
            sb.AppendLine("</div></div>")

            sb.AppendLine("</div>")
            sb.AppendLine("<!-- End Product preview -->")

            Return (sb.ToString)
        End Function
        'Build the preview of the product using the XML info
        Public Shared Function buildApparelPreview(ByVal XMLMarkup As String) As String
            Dim sb As New StringBuilder
            Dim xmlDoc As New XmlDocument
            Dim sDescription As String

            Try
                xmlDoc.LoadXml(XMLMarkup)
            Catch ex As System.Exception
                Return (XMLMarkup)
            End Try


            sDescription = getXMLNodeString(xmlDoc, "/root/product/description")

            sb.AppendLine("<!-- Product preview -->")
            sb.AppendLine("<div class=""IndividualBox"">")

            sb.AppendLine("<div class=""PImageBox""><div class=""PImage"" style=""background-color:#FFFFFF;"">")
            sb.AppendLine(replaceThumbnailImage(getXMLNodeString(xmlDoc, "/root/product/productimage")))
            sb.AppendLine("</div></div>")

            sb.AppendLine("<div class=""PInfoBox""><div class=""PHeader"">")
            sb.AppendLine("<a href=""" & getXMLNodeString(xmlDoc, "/root/QuickLink") & """>")
            sb.AppendLine(getXMLNodeString(xmlDoc, "/root/product/productname"))
            sb.AppendLine("</a>")
            sb.AppendLine("</div>")

            sb.AppendLine("<div class=""PNumber"">")
            sb.Append("Part number: ")
            sb.AppendLine(getXMLNodeString(xmlDoc, "/root/product/partnumber"))
            sb.AppendLine("</div>")

            sb.AppendLine("<div class=""Description"">")

            If (sDescription.Length > 150) Then
                sb.AppendLine(sDescription.Substring(0, 150) & " (...)")
            Else
                sb.AppendLine(sDescription)
            End If
            sb.AppendLine("</div></div>")

            sb.AppendLine("</div>")


            Return (sb.ToString)
        End Function
        Public Shared Function displayChildrenByTaxonomyID(ByVal taxonomyID As Integer, ByVal cssClass As String) As String
            Dim tAPI As New Ektron.Cms.API.Content.Taxonomy()
            Dim tRequest As New Ektron.Cms.TaxonomyRequest()
            Dim tData As Ektron.Cms.TaxonomyData
            Dim tItemDataArray() As Ektron.Cms.TaxonomyItemData
            Dim tItemDataElement As Ektron.Cms.TaxonomyItemData
            Dim sb As New StringBuilder()

            tRequest.TaxonomyId = taxonomyID
            tRequest.TaxonomyLanguage = 1033
            tData = tAPI.LoadTaxonomy(tRequest)

            If tData.TaxonomyHasChildren = True Then
                tItemDataArray = tData.TaxonomyItems()
                For Each tItemDataElement In tItemDataArray
                    sb.Append(tItemDataElement.TaxonomyItemTitle)
                    sb.Append("<BR />")
                    'sb.Append(ControlChars.CrLf)
                Next
            Else
                Return ("No children")
            End If

            Return (sb.ToString())
        End Function
        Public Shared Function getMetaData(ByVal myContentBlock As Ektron.Cms.Controls.ContentBlock, ByVal MetaDataToRetreive As String) As String
            'Double check
            Dim MetadataList As Ektron.Cms.CustomAttributeList
            Dim Metadata As Ektron.Cms.CustomAttribute

            MetadataList = myContentBlock.GetMetaData()

            If (MetadataList IsNot Nothing) AndAlso (MetadataList.AttributeList IsNot Nothing) Then
                '  Get the metadata value by the name of the collection selector:
                Metadata = MetadataList.GetItemByName(MetaDataToRetreive)
                If Metadata IsNot Nothing Then
                    Return (Metadata.Value)
                Else
                    Return ("Not available")
                End If
            Else
                Return ("Not available")
            End If
        End Function


        Public Shared Function buildSpecs(ByVal XMLDoc As XmlDocument, ByVal xPath As String) As String
            Dim XMLNode As XmlNode
            Dim XMLNodeList As XmlNodeList
            Dim sb As New StringBuilder

            XMLNodeList = getMultipleXMLNodes(XMLDoc, xPath)
            For Each XMLNode In XMLNodeList
                sb.Append(XMLNode.InnerXml)
            Next
            Return (sb.ToString())
        End Function

        'Not used anymore but left here for reference
        'Private Function buildApplicationIcons(ByVal XMLDoc As XmlDocument, ByVal xPath As String) As String
        '    Dim XMLNode As XmlNode
        '    Dim XMLNodeList As XmlNodeList
        '    Dim sb As New StringBuilder

        '    XMLNodeList = getMultipleXMLNodes(XMLDoc, xPath)
        '    For Each XMLNode In XMLNodeList
        '        sb.Append("<div class='")
        '        sb.Append(XMLNode.InnerText)
        '        sb.Append("'></div>")
        '    Next
        '    Return (sb.ToString())
        'End Function
        Public Shared Function buildInstructionLinks(ByVal XMLDoc As XmlDocument, ByVal xPath As String) As String
            Dim XMLNode As XmlNode
            Dim XMLNodeList As XmlNodeList
            Dim sb As New StringBuilder

            XMLNodeList = getMultipleXMLNodes(XMLDoc, xPath)
            sb.Append("<ul>")
            For Each XMLNode In XMLNodeList
                sb.Append("<li class='product_instructionimage'>")
                sb.Append(XMLNode.InnerXml)
                sb.Append("</li>")
            Next
            sb.Append("</ul>")
            Return (sb.ToString())
        End Function

        Public Shared Function getMultipleXMLNodes(ByVal XMLDoc As XmlDocument, ByVal xPath As String) As XmlNodeList
            Dim XMLNodeList As XmlNodeList

            XMLNodeList = XMLDoc.SelectNodes(xPath)

            Return (XMLNodeList)
        End Function
        Public Shared Function getXMLNodeString(ByVal XMLDoc As XmlDocument, ByVal xPath As String) As String
            Dim XMLNode As System.Xml.XmlNode
            XMLNode = XMLDoc.SelectSingleNode(xPath)
            If XMLNode IsNot Nothing Then
                Return (XMLNode.InnerXml)
            Else
                Return "(N/A)"
            End If
        End Function
        Public Shared Function getXMLNodeString(ByVal XMLDoc As XmlDocument, ByVal xPath As String, ByVal defaultValue As String) As String
            Dim XMLNode As System.Xml.XmlNode
            XMLNode = XMLDoc.SelectSingleNode(xPath)
            If XMLNode IsNot Nothing Then
                Return (XMLNode.InnerXml)
            Else
                'Return defaultValue if none is found
                Return defaultValue
            End If
        End Function
        'Returns a number formatted for currency
        Public Shared Function getXMLNodeCurrency(ByVal XMLDoc As XmlDocument, ByVal xPath As String) As String
            Dim XMLNode As System.Xml.XmlNode
            XMLNode = XMLDoc.SelectSingleNode(xPath)
            If XMLNode IsNot Nothing Then
                Try
                    Return (String.Format("{0:C2}", Convert.ToDouble(XMLNode.InnerText)))
                Catch e As FormatException
                    Return ("(N/A)")
                End Try

            Else
                Return "(N/A)"
            End If
        End Function
    End Class
End Namespace