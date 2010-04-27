
Partial Class _default
    Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request.QueryString("id")) Then
            BlogEntriesMSD.DisplayXslt = "ecmBlog"
            BlogEntriesMSD.CssClass = "blogEntriesLong"
            CollectionMSDBanner.Visible = False
            rightMain.Visible = False

        End If

	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
		If CollectionMSD.EkItems.Length Then
			CollectionMSD.Text = CollectionMSD.EkItems(0).Html
	    End If
		
		If CollectionMSDBanner.EkItems.Length Then
			CollectionMSDBanner.Text = CollectionMSDBanner.EkItems(0).Html 
		End If
		
		'If CollectionMSDNewProducts.EkItems.Length Then
		'	CollectionMSDNewProducts.Text = CollectionMSDNewProducts.EkItems(0).Html 
		'End If
	End Sub
End Class
