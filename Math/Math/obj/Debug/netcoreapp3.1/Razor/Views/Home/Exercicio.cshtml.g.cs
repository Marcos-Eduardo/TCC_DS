#pragma checksum "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Exercicio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "317e0e291e7b5b8b4998f929446ebf88d23c9b01"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Exercicio), @"mvc.1.0.view", @"/Views/Home/Exercicio.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"317e0e291e7b5b8b4998f929446ebf88d23c9b01", @"/Views/Home/Exercicio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51037c4a57b97a33f9a7cb7124b1d362641358d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Exercicio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<QuestaoViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/fe/Quiz/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/fe/Quiz/js/script.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Exercicio.cshtml"
  
    ViewData["Title"] = "Exercicio";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "317e0e291e7b5b8b4998f929446ebf88d23c9b014501", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- FontAweome CDN Link for Icons -->\r\n    <script src=\"https://kit.fontawesome.com/a076d05399.js\"></script>\r\n");
            }
            );
            WriteLiteral(@"
<section class=""mbr-fullscreen"" style=""background: #f39f0b;"">
    <!-- start Quiz button -->
    <div class=""start_btn""><button>Começar</button></div>

    <!-- Info Box -->
    <div class=""info_box"">
        <div class=""info-title""><span>Algumas Regras do Quiz</span></div>
        <div class=""info-list"">
            <div class=""info"">1. Você terá apenas <span>15 segundos</span> por questão.</div>
            <div class=""info"">2. Depois de selecionar sua resposta, não poderá selecionar outra.</div>
            <div class=""info"">3. Você não pode selecionar nenhuma opção depois que o tempo acabar.</div>
            <div class=""info"">4. Você não pode sair do Quiz enquanto está jogando.</div>
            <div class=""info"">5. Você receberá pontos com base nas suas respostas corretas.</div>
        </div>
        <div class=""buttons"">
            <button class=""quit"">Sair</button>
            <button class=""restart"">Continuar</button>
        </div>
    </div>

    <!-- Quiz Box -->
    <div ");
            WriteLiteral("class=\"quiz_box\">\r\n        <header>\r\n            <div class=\"title\">");
#nullable restore
#line 35 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Exercicio.cshtml"
                          Write(ViewData["QuizNome"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            <div class=""timer"">
                <div class=""time_left_txt"">Tempo</div>
                <div class=""timer_sec"">15</div>
            </div>
            <div class=""time_line""></div>
        </header>
        <section>
            <div class=""que_text"">
                <!-- Here I've inserted question from JavaScript -->
            </div>
            <div class=""option_list"">
                <!-- Here I've inserted options from JavaScript -->
            </div>
        </section>

        <!-- footer of Quiz Box -->
        <footer>
            <div class=""total_que"">
                <!-- Here I've inserted Question Count Number from JavaScript -->
            </div>
            <button class=""next_btn"">Próxima</button>
        </footer>
    </div>

    <!-- Result Box -->
    <div class=""result_box"">
        <div class=""icon"">
            <i class=""fas fa-crown""></i>
        </div>
        <div class=""complete_text"">Você Completou o Quiz!</div>
        <div");
            WriteLiteral(@" class=""score_text"">
            <!-- Here I've inserted Score Result from JavaScript -->
        </div>
        <div class=""buttons"">
            <button class=""restart"">Jogar Novamente</button>
            <button class=""quit"">Sair</button>
        </div>
    </div>
</section>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        let model = \'");
#nullable restore
#line 78 "C:\Repositories\TCCs\Desenvolvimento de Sistemas\Math\Math\Views\Home\Exercicio.cshtml"
                Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        var questions = JSON.parse(model);\r\n    </script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "317e0e291e7b5b8b4998f929446ebf88d23c9b019140", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<QuestaoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
