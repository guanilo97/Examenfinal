#pragma checksum "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\Ingreso\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9502169f23f8da4a6d15e08361b5ad24c57676d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ingreso_Index), @"mvc.1.0.view", @"/Views/Ingreso/Index.cshtml")]
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
#line 1 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\_ViewImports.cshtml"
using ExamenFinal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\_ViewImports.cshtml"
using ExamenFinal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9502169f23f8da4a6d15e08361b5ad24c57676d3", @"/Views/Ingreso/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2dfc294bf8d6131f460c8b716bd6e5797132710", @"/Views/_ViewImports.cshtml")]
    public class Views_Ingreso_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n    <a href=\"/Cuentas/Index\">volver</a>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 72, "\"", 121, 2);
            WriteAttributeValue("", 79, "/Ingreso/Crear?idcuenta=", 79, 24, true);
#nullable restore
#line 3 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\Ingreso\Index.cshtml"
WriteAttributeValue("", 103, ViewBag.Id_Cuenta, 103, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary"">Crear ingreso</a>
    <br />
    <table class=""table table-hover"">
        <thead>
            <tr>
                <th>Fecha y hora</th>
                <th>Monto</th>
                <th>Decripción</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 14 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\Ingreso\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 17 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\Ingreso\Index.cshtml"
               Write(item.Fecha_Hora);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 18 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\Ingreso\Index.cshtml"
               Write(item.Monto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\Ingreso\Index.cshtml"
               Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 21 "C:\Users\josel\OneDrive\Documentos\Visual Studio 2019\Projects\ExamenFinal\ExamenFinal\Views\Ingreso\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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