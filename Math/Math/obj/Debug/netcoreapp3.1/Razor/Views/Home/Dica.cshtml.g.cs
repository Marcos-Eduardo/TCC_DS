#pragma checksum "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Dica.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c503a926c2baa7b7e3d8178bc5ce14c909101133"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dica), @"mvc.1.0.view", @"/Views/Home/Dica.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\_ViewImports.cshtml"
using Math;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\_ViewImports.cshtml"
using Math.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c503a926c2baa7b7e3d8178bc5ce14c909101133", @"/Views/Home/Dica.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51037c4a57b97a33f9a7cb7124b1d362641358d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dica : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DicaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Dica.cshtml"
  
    ViewData["Title"] = "Dica";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""header1 cid-s5dDaxoqlV"" id=""header16-1b"">
    <div class=""container"">
        <div class=""row justify-content-md-center"">
            <div class=""col-md-10 align-center"">
                <h1 class=""mbr-section-title mbr-bold pb-3 mbr-fonts-style display-2"">");
#nullable restore
#line 10 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Dica.cshtml"
                                                                                 Write(Model.Dica.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
            </div>
        </div>
    </div>
</section>

<section class=""cid-s5cSteDgd9"" id=""video3-18"">
    <figure class=""mbr-figure align-center container"">
        <div class=""video-block"" style=""width: 80%;"">
            <div><iframe class=""mbr-embedded-video""");
            BeginWriteAttribute("src", " src=\"", 639, "\"", 736, 1);
#nullable restore
#line 19 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Dica.cshtml"
WriteAttributeValue("", 645, string.Concat(Model.Dica.LinkVideo, "?rel=0&amp;amp;showinfo=0&amp;autoplay=0&amp;loop=0"), 645, 91, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" width=""1280"" height=""720"" frameborder=""0"" allowfullscreen></iframe></div>
        </div>
    </figure>
</section>

<section class=""mbr-section article content1 cid-s5dOtziPcb"" id=""content2-1i"">
    <div class=""container"">
        <div class=""media-container-row"">
            <div class=""mbr-text col-12 col-md-8 mbr-fonts-style display-7"">
                <blockquote>
                    <p style=""font-size: 1.09rem;"">
                        ");
#nullable restore
#line 30 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Dica.cshtml"
                   Write(Model.Dica.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </blockquote>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DicaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
