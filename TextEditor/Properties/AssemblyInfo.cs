using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("TextEditor")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("TextEditor")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible を false に設定すると、その型はこのアセンブリ内で COM コンポーネントから
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("9e523f39-3c61-45dd-9057-8da92bbd1d1f")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.0")]

// 以下の属性は FxCop 警告 "CA2232 : Microsoft.Usage : STAThreadAttribute をアセンブリに追加します" を抑制しますが、
// これは、デバイス アプリケーションで STA スレッドがサポートされないためです。
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
