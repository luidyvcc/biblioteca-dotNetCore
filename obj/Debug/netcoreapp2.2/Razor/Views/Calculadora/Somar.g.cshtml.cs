#pragma checksum "D:\Documents\Cursos\FIB\Engenharia_de_Software\dot_net_avancado\projetos\PrjBiblioteca\Views\Calculadora\Somar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c3cd757442dd48a48524e794bb0909a84ac8de9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Calculadora_Somar), @"mvc.1.0.view", @"/Views/Calculadora/Somar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Calculadora/Somar.cshtml", typeof(AspNetCore.Views_Calculadora_Somar))]
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
#line 1 "D:\Documents\Cursos\FIB\Engenharia_de_Software\dot_net_avancado\projetos\PrjBiblioteca\Views\_ViewImports.cshtml"
using PrjBiblioteca;

#line default
#line hidden
#line 2 "D:\Documents\Cursos\FIB\Engenharia_de_Software\dot_net_avancado\projetos\PrjBiblioteca\Views\_ViewImports.cshtml"
using PrjBiblioteca.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c3cd757442dd48a48524e794bb0909a84ac8de9", @"/Views/Calculadora/Somar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09d6db75e6300a87dc7e310818a0f6ab2f03017b", @"/Views/_ViewImports.cshtml")]
    public class Views_Calculadora_Somar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 14, true);
            WriteLiteral("O resultado é ");
            EndContext();
            BeginContext(15, 15, false);
#line 1 "D:\Documents\Cursos\FIB\Engenharia_de_Software\dot_net_avancado\projetos\PrjBiblioteca\Views\Calculadora\Somar.cshtml"
         Write(ViewData["res"]);

#line default
#line hidden
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
