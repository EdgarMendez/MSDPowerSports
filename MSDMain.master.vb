 Partial Class MSDMain
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Utilities.RegisterBaseUrl(Me.Page)
    End Sub
Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Response.Cache.SetExpires(DateTime.Now.AddSeconds(20))
            'Response.Cache.SetCacheability(HttpCacheability.Public)
            'Response.Cache.SetValidUntilExpires(True)
            'Response.Cache.VaryByParams("id") = True
            'Response.Cache.SetVaryByCustom("cmsCache")
    End Sub
End Class

