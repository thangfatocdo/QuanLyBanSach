; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [134 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [268 x i32] [
	i32 42639949, ; 0: System.Threading.Thread => 0x28aa24d => 125
	i32 67008169, ; 1: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 2: Microsoft.Maui.Graphics.dll => 0x44bb714 => 49
	i32 117431740, ; 3: System.Runtime.InteropServices => 0x6ffddbc => 118
	i32 165246403, ; 4: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 68
	i32 172961045, ; 5: Syncfusion.Maui.Core.dll => 0xa4f2d15 => 62
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 87
	i32 195452805, ; 7: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 8: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 9: System.ComponentModel => 0xc38ff48 => 100
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 66
	i32 270014963, ; 11: OneSignalSDK.DotNet.Android => 0x101819f3 => 54
	i32 280992041, ; 12: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 317674968, ; 13: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 14: Xamarin.AndroidX.Activity.dll => 0x13031348 => 63
	i32 336156722, ; 15: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 16: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 75
	i32 356389973, ; 17: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 379916513, ; 18: System.Threading.Thread.dll => 0x16a510e1 => 125
	i32 385762202, ; 19: System.Memory.dll => 0x16fe439a => 110
	i32 395744057, ; 20: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 426620334, ; 21: OneSignalSDK.DotNet.Core => 0x196db5ae => 55
	i32 435591531, ; 22: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 436088230, ; 23: OneSignalSDK.DotNet => 0x19fe2da6 => 56
	i32 442565967, ; 24: System.Collections => 0x1a61054f => 97
	i32 450948140, ; 25: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 74
	i32 469710990, ; 26: System.dll => 0x1bff388e => 128
	i32 498788369, ; 27: System.ObjectModel => 0x1dbae811 => 115
	i32 500358224, ; 28: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 29: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 30: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 44
	i32 525008092, ; 31: SkiaSharp.dll => 0x1f4afcdc => 57
	i32 539058512, ; 32: Microsoft.Extensions.Logging => 0x20216150 => 41
	i32 592146354, ; 33: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 627609679, ; 34: Xamarin.AndroidX.CustomView => 0x2568904f => 72
	i32 627931235, ; 35: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 662205335, ; 36: System.Text.Encodings.Web.dll => 0x27787397 => 122
	i32 672442732, ; 37: System.Collections.Concurrent => 0x2814a96c => 94
	i32 688181140, ; 38: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 706645707, ; 39: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 40: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 41: System.Runtime.Loader.dll => 0x2b15ed29 => 119
	i32 759454413, ; 42: System.Net.Requests => 0x2d445acd => 113
	i32 775507847, ; 43: System.IO.Compression => 0x2e394f87 => 107
	i32 777317022, ; 44: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 45: Microsoft.Extensions.Options => 0x2f0980eb => 43
	i32 823281589, ; 46: System.Private.Uri.dll => 0x311247b5 => 116
	i32 830298997, ; 47: System.IO.Compression.Brotli => 0x317d5b75 => 106
	i32 904024072, ; 48: System.ComponentModel.Primitives.dll => 0x35e25008 => 98
	i32 926902833, ; 49: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 967690846, ; 50: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 75
	i32 992768348, ; 51: System.Collections.dll => 0x3b2c715c => 97
	i32 1012816738, ; 52: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 85
	i32 1019214401, ; 53: System.Drawing => 0x3cbffa41 => 105
	i32 1028951442, ; 54: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 40
	i32 1029334545, ; 55: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 56: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 64
	i32 1036536393, ; 57: System.Drawing.Primitives.dll => 0x3dc84a49 => 104
	i32 1044663988, ; 58: System.Linq.Expressions.dll => 0x3e444eb4 => 108
	i32 1052210849, ; 59: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 77
	i32 1082857460, ; 60: System.ComponentModel.TypeConverter => 0x408b17f4 => 99
	i32 1084122840, ; 61: Xamarin.Kotlin.StdLib => 0x409e66d8 => 91
	i32 1098259244, ; 62: System => 0x41761b2c => 128
	i32 1118262833, ; 63: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 64: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 65: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 82
	i32 1203215381, ; 66: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1208641965, ; 67: System.Diagnostics.Process => 0x480a69ad => 103
	i32 1214827643, ; 68: CommunityToolkit.Mvvm => 0x4868cc7b => 35
	i32 1234928153, ; 69: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1260983243, ; 70: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1293217323, ; 71: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 73
	i32 1324164729, ; 72: System.Linq => 0x4eed2679 => 109
	i32 1373134921, ; 73: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 74: Xamarin.AndroidX.SavedState => 0x52114ed3 => 85
	i32 1406073936, ; 75: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 69
	i32 1430672901, ; 76: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1461004990, ; 77: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1462112819, ; 78: System.IO.Compression.dll => 0x57261233 => 107
	i32 1469204771, ; 79: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 65
	i32 1470490898, ; 80: Microsoft.Extensions.Primitives => 0x57a5e912 => 44
	i32 1480492111, ; 81: System.IO.Compression.Brotli.dll => 0x583e844f => 106
	i32 1493001747, ; 82: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1514721132, ; 83: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1543031311, ; 84: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 124
	i32 1551623176, ; 85: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1560353690, ; 86: OneSignalSDK.DotNet.Android.dll => 0x5d011b9a => 54
	i32 1622152042, ; 87: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 79
	i32 1623212457, ; 88: SkiaSharp.Views.Maui.Controls => 0x60c041a9 => 59
	i32 1624863272, ; 89: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 89
	i32 1636350590, ; 90: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 71
	i32 1639515021, ; 91: System.Net.Http.dll => 0x61b9038d => 111
	i32 1639986890, ; 92: System.Text.RegularExpressions => 0x61c036ca => 124
	i32 1657153582, ; 93: System.Runtime => 0x62c6282e => 120
	i32 1658251792, ; 94: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 90
	i32 1670822929, ; 95: Doan1 => 0x6396bc11 => 93
	i32 1677501392, ; 96: System.Net.Primitives.dll => 0x63fca3d0 => 112
	i32 1679769178, ; 97: System.Security.Cryptography => 0x641f3e5a => 121
	i32 1729485958, ; 98: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 67
	i32 1736233607, ; 99: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1743415430, ; 100: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1766324549, ; 101: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 87
	i32 1770582343, ; 102: Microsoft.Extensions.Logging.dll => 0x6988f147 => 41
	i32 1780572499, ; 103: Mono.Android.Runtime.dll => 0x6a216153 => 132
	i32 1782862114, ; 104: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 105: Xamarin.AndroidX.Fragment => 0x6a96652d => 74
	i32 1793755602, ; 106: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 107: Xamarin.AndroidX.Loader => 0x6bcd3296 => 79
	i32 1813058853, ; 108: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 91
	i32 1813201214, ; 109: Xamarin.Google.Android.Material => 0x6c13413e => 90
	i32 1818569960, ; 110: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 83
	i32 1828688058, ; 111: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 42
	i32 1842015223, ; 112: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1853025655, ; 113: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 114: System.Linq.Expressions => 0x6ec71a65 => 108
	i32 1875935024, ; 115: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1910275211, ; 116: System.Collections.NonGeneric.dll => 0x71dc7c8b => 95
	i32 1961813231, ; 117: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 86
	i32 1968388702, ; 118: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 37
	i32 2003115576, ; 119: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 120: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 77
	i32 2025202353, ; 121: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2045470958, ; 122: System.Private.Xml => 0x79eb68ee => 117
	i32 2055257422, ; 123: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 76
	i32 2066184531, ; 124: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2079903147, ; 125: System.Runtime.dll => 0x7bf8cdab => 120
	i32 2090596640, ; 126: System.Numerics.Vectors => 0x7c9bf920 => 114
	i32 2127167465, ; 127: System.Console => 0x7ec9ffe9 => 101
	i32 2140476313, ; 128: OneSignalSDK.DotNet.Core.dll => 0x7f951399 => 55
	i32 2142473426, ; 129: System.Collections.Specialized => 0x7fb38cd2 => 96
	i32 2159891885, ; 130: Microsoft.Maui => 0x80bd55ad => 47
	i32 2169148018, ; 131: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 132: Microsoft.Extensions.Options.dll => 0x820d22b3 => 43
	i32 2188602587, ; 133: Microcharts.Maui => 0x82736cdb => 36
	i32 2192057212, ; 134: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 42
	i32 2193016926, ; 135: System.ObjectModel.dll => 0x82b6c85e => 115
	i32 2201107256, ; 136: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 92
	i32 2201231467, ; 137: System.Net.Http => 0x8334206b => 111
	i32 2207618523, ; 138: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 139: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 38
	i32 2270573516, ; 140: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 141: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 84
	i32 2303942373, ; 142: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 143: System.Private.CoreLib.dll => 0x896b7878 => 130
	i32 2349911137, ; 144: OneSignalSDK.DotNet.Android.Core.Binding => 0x8c10cc61 => 50
	i32 2353062107, ; 145: System.Net.Primitives => 0x8c40e0db => 112
	i32 2354730003, ; 146: Syncfusion.Licensing => 0x8c5a5413 => 61
	i32 2364201794, ; 147: SkiaSharp.Views.Maui.Core => 0x8ceadb42 => 60
	i32 2368005991, ; 148: System.Xml.ReaderWriter.dll => 0x8d24e767 => 127
	i32 2371007202, ; 149: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 37
	i32 2395872292, ; 150: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2427813419, ; 151: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 152: System.Console.dll => 0x912896e5 => 101
	i32 2471841756, ; 153: netstandard.dll => 0x93554fdc => 129
	i32 2475788418, ; 154: Java.Interop.dll => 0x93918882 => 131
	i32 2480646305, ; 155: Microsoft.Maui.Controls => 0x93dba8a1 => 45
	i32 2550873716, ; 156: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2570120770, ; 157: System.Text.Encodings.Web => 0x9930ee42 => 122
	i32 2593496499, ; 158: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 159: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 92
	i32 2617129537, ; 160: System.Private.Xml.dll => 0x9bfe3a41 => 117
	i32 2620871830, ; 161: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 71
	i32 2625339995, ; 162: SkiaSharp.Views.Maui.Core.dll => 0x9c7b825b => 60
	i32 2626831493, ; 163: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2663698177, ; 164: System.Runtime.Loader => 0x9ec4cf01 => 119
	i32 2665622720, ; 165: System.Drawing.Primitives => 0x9ee22cc0 => 104
	i32 2732626843, ; 166: Xamarin.AndroidX.Activity => 0xa2e0939b => 63
	i32 2737747696, ; 167: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 65
	i32 2752995522, ; 168: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 169: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 46
	i32 2764765095, ; 170: Microsoft.Maui.dll => 0xa4caf7a7 => 47
	i32 2778768386, ; 171: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 88
	i32 2785988530, ; 172: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2795602088, ; 173: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 58
	i32 2801831435, ; 174: Microsoft.Maui.Graphics => 0xa7008e0b => 49
	i32 2806116107, ; 175: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2809624274, ; 176: OneSignalSDK.DotNet.Android.Notifications.Binding => 0xa77776d2 => 53
	i32 2810250172, ; 177: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 69
	i32 2831556043, ; 178: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2853208004, ; 179: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 88
	i32 2861189240, ; 180: Microsoft.Maui.Essentials => 0xaa8a4878 => 48
	i32 2868557005, ; 181: Syncfusion.Licensing.dll => 0xaafab4cd => 61
	i32 2909740682, ; 182: System.Private.CoreLib => 0xad6f1e8a => 130
	i32 2912489636, ; 183: SkiaSharp.Views.Android => 0xad9910a4 => 58
	i32 2916838712, ; 184: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 89
	i32 2919462931, ; 185: System.Numerics.Vectors.dll => 0xae037813 => 114
	i32 2956865972, ; 186: OneSignalSDK.DotNet.Android.Core.Binding.dll => 0xb03e31b4 => 50
	i32 2959614098, ; 187: System.ComponentModel.dll => 0xb0682092 => 100
	i32 2978675010, ; 188: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 73
	i32 2987532451, ; 189: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 86
	i32 3038032645, ; 190: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3057625584, ; 191: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 80
	i32 3059408633, ; 192: Mono.Android.Runtime => 0xb65adef9 => 132
	i32 3059793426, ; 193: System.ComponentModel.Primitives => 0xb660be12 => 98
	i32 3077302341, ; 194: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3085677078, ; 195: OneSignalSDK.DotNet.Android.InAppMessages.Binding.dll => 0xb7ebb216 => 51
	i32 3147228406, ; 196: Syncfusion.Maui.Core => 0xbb96e4f6 => 62
	i32 3178803400, ; 197: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 81
	i32 3220365878, ; 198: System.Threading => 0xbff2e236 => 126
	i32 3258312781, ; 199: Xamarin.AndroidX.CardView => 0xc235e84d => 67
	i32 3305363605, ; 200: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 201: System.Net.Requests.dll => 0xc5b097e4 => 113
	i32 3317135071, ; 202: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 72
	i32 3340387945, ; 203: SkiaSharp => 0xc71a4669 => 57
	i32 3346324047, ; 204: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 82
	i32 3357674450, ; 205: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3358260929, ; 206: System.Text.Json => 0xc82afec1 => 123
	i32 3362522851, ; 207: Xamarin.AndroidX.Core => 0xc86c06e3 => 70
	i32 3366347497, ; 208: Java.Interop => 0xc8a662e9 => 131
	i32 3374999561, ; 209: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 84
	i32 3381016424, ; 210: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3393046787, ; 211: OneSignalSDK.DotNet.Android.Location.Binding => 0xca3dc903 => 52
	i32 3428513518, ; 212: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 39
	i32 3430777524, ; 213: netstandard => 0xcc7d82b4 => 129
	i32 3463511458, ; 214: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 215: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 99
	i32 3473156932, ; 216: SkiaSharp.Views.Maui.Controls.dll => 0xcf042b44 => 59
	i32 3476120550, ; 217: Mono.Android => 0xcf3163e6 => 133
	i32 3479583265, ; 218: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3484440000, ; 219: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3485117614, ; 220: System.Text.Json.dll => 0xcfbaacae => 123
	i32 3501697948, ; 221: OneSignalSDK.DotNet.Android.Location.Binding.dll => 0xd0b7ab9c => 52
	i32 3580758918, ; 222: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3608519521, ; 223: System.Linq.dll => 0xd715a361 => 109
	i32 3625673393, ; 224: OneSignalSDK.DotNet.Android.Notifications.Binding.dll => 0xd81b62b1 => 53
	i32 3641597786, ; 225: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 76
	i32 3643446276, ; 226: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 227: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 81
	i32 3657292374, ; 228: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 38
	i32 3672681054, ; 229: Mono.Android.dll => 0xdae8aa5e => 133
	i32 3682565725, ; 230: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 66
	i32 3697841164, ; 231: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3724971120, ; 232: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 80
	i32 3732890190, ; 233: OneSignalSDK.DotNet.Android.InAppMessages.Binding => 0xde7f624e => 51
	i32 3748608112, ; 234: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 102
	i32 3786282454, ; 235: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 68
	i32 3792276235, ; 236: System.Collections.NonGeneric => 0xe2098b0b => 95
	i32 3802395368, ; 237: System.Collections.Specialized.dll => 0xe2a3f2e8 => 96
	i32 3823082795, ; 238: System.Security.Cryptography.dll => 0xe3df9d2b => 121
	i32 3841636137, ; 239: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 40
	i32 3849253459, ; 240: System.Runtime.InteropServices.dll => 0xe56ef253 => 118
	i32 3875151090, ; 241: OneSignalSDK.DotNet.dll => 0xe6fa1cf2 => 56
	i32 3889960447, ; 242: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 243: System.Collections.Concurrent.dll => 0xe839deed => 94
	i32 3896760992, ; 244: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 70
	i32 3928044579, ; 245: System.Xml.ReaderWriter => 0xea213423 => 127
	i32 3931092270, ; 246: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 83
	i32 3955647286, ; 247: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 64
	i32 3980434154, ; 248: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3987592930, ; 249: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4003436829, ; 250: System.Diagnostics.Process.dll => 0xee9f991d => 103
	i32 4025784931, ; 251: System.Memory => 0xeff49a63 => 110
	i32 4046471985, ; 252: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 46
	i32 4073602200, ; 253: System.Threading.dll => 0xf2ce3c98 => 126
	i32 4094352644, ; 254: Microsoft.Maui.Essentials.dll => 0xf40add04 => 48
	i32 4099507663, ; 255: System.Drawing.dll => 0xf45985cf => 105
	i32 4100113165, ; 256: System.Private.Uri => 0xf462c30d => 116
	i32 4102112229, ; 257: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4114082824, ; 258: Doan1.dll => 0xf537ec08 => 93
	i32 4125707920, ; 259: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 260: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 39
	i32 4150914736, ; 261: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4182413190, ; 262: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 78
	i32 4189085287, ; 263: Microcharts.Maui.dll => 0xf9b05e67 => 36
	i32 4213026141, ; 264: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 102
	i32 4271975918, ; 265: Microsoft.Maui.Controls.dll => 0xfea12dee => 45
	i32 4274623895, ; 266: CommunityToolkit.Mvvm.dll => 0xfec99597 => 35
	i32 4292120959 ; 267: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 78
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [268 x i32] [
	i32 125, ; 0
	i32 33, ; 1
	i32 49, ; 2
	i32 118, ; 3
	i32 68, ; 4
	i32 62, ; 5
	i32 87, ; 6
	i32 30, ; 7
	i32 31, ; 8
	i32 100, ; 9
	i32 66, ; 10
	i32 54, ; 11
	i32 2, ; 12
	i32 30, ; 13
	i32 63, ; 14
	i32 15, ; 15
	i32 75, ; 16
	i32 14, ; 17
	i32 125, ; 18
	i32 110, ; 19
	i32 34, ; 20
	i32 55, ; 21
	i32 26, ; 22
	i32 56, ; 23
	i32 97, ; 24
	i32 74, ; 25
	i32 128, ; 26
	i32 115, ; 27
	i32 13, ; 28
	i32 7, ; 29
	i32 44, ; 30
	i32 57, ; 31
	i32 41, ; 32
	i32 21, ; 33
	i32 72, ; 34
	i32 19, ; 35
	i32 122, ; 36
	i32 94, ; 37
	i32 1, ; 38
	i32 16, ; 39
	i32 4, ; 40
	i32 119, ; 41
	i32 113, ; 42
	i32 107, ; 43
	i32 25, ; 44
	i32 43, ; 45
	i32 116, ; 46
	i32 106, ; 47
	i32 98, ; 48
	i32 28, ; 49
	i32 75, ; 50
	i32 97, ; 51
	i32 85, ; 52
	i32 105, ; 53
	i32 40, ; 54
	i32 3, ; 55
	i32 64, ; 56
	i32 104, ; 57
	i32 108, ; 58
	i32 77, ; 59
	i32 99, ; 60
	i32 91, ; 61
	i32 128, ; 62
	i32 16, ; 63
	i32 22, ; 64
	i32 82, ; 65
	i32 20, ; 66
	i32 103, ; 67
	i32 35, ; 68
	i32 18, ; 69
	i32 2, ; 70
	i32 73, ; 71
	i32 109, ; 72
	i32 32, ; 73
	i32 85, ; 74
	i32 69, ; 75
	i32 0, ; 76
	i32 6, ; 77
	i32 107, ; 78
	i32 65, ; 79
	i32 44, ; 80
	i32 106, ; 81
	i32 10, ; 82
	i32 5, ; 83
	i32 124, ; 84
	i32 25, ; 85
	i32 54, ; 86
	i32 79, ; 87
	i32 59, ; 88
	i32 89, ; 89
	i32 71, ; 90
	i32 111, ; 91
	i32 124, ; 92
	i32 120, ; 93
	i32 90, ; 94
	i32 93, ; 95
	i32 112, ; 96
	i32 121, ; 97
	i32 67, ; 98
	i32 23, ; 99
	i32 1, ; 100
	i32 87, ; 101
	i32 41, ; 102
	i32 132, ; 103
	i32 17, ; 104
	i32 74, ; 105
	i32 9, ; 106
	i32 79, ; 107
	i32 91, ; 108
	i32 90, ; 109
	i32 83, ; 110
	i32 42, ; 111
	i32 29, ; 112
	i32 26, ; 113
	i32 108, ; 114
	i32 8, ; 115
	i32 95, ; 116
	i32 86, ; 117
	i32 37, ; 118
	i32 5, ; 119
	i32 77, ; 120
	i32 0, ; 121
	i32 117, ; 122
	i32 76, ; 123
	i32 4, ; 124
	i32 120, ; 125
	i32 114, ; 126
	i32 101, ; 127
	i32 55, ; 128
	i32 96, ; 129
	i32 47, ; 130
	i32 12, ; 131
	i32 43, ; 132
	i32 36, ; 133
	i32 42, ; 134
	i32 115, ; 135
	i32 92, ; 136
	i32 111, ; 137
	i32 14, ; 138
	i32 38, ; 139
	i32 8, ; 140
	i32 84, ; 141
	i32 18, ; 142
	i32 130, ; 143
	i32 50, ; 144
	i32 112, ; 145
	i32 61, ; 146
	i32 60, ; 147
	i32 127, ; 148
	i32 37, ; 149
	i32 13, ; 150
	i32 10, ; 151
	i32 101, ; 152
	i32 129, ; 153
	i32 131, ; 154
	i32 45, ; 155
	i32 11, ; 156
	i32 122, ; 157
	i32 20, ; 158
	i32 92, ; 159
	i32 117, ; 160
	i32 71, ; 161
	i32 60, ; 162
	i32 15, ; 163
	i32 119, ; 164
	i32 104, ; 165
	i32 63, ; 166
	i32 65, ; 167
	i32 21, ; 168
	i32 46, ; 169
	i32 47, ; 170
	i32 88, ; 171
	i32 27, ; 172
	i32 58, ; 173
	i32 49, ; 174
	i32 6, ; 175
	i32 53, ; 176
	i32 69, ; 177
	i32 19, ; 178
	i32 88, ; 179
	i32 48, ; 180
	i32 61, ; 181
	i32 130, ; 182
	i32 58, ; 183
	i32 89, ; 184
	i32 114, ; 185
	i32 50, ; 186
	i32 100, ; 187
	i32 73, ; 188
	i32 86, ; 189
	i32 34, ; 190
	i32 80, ; 191
	i32 132, ; 192
	i32 98, ; 193
	i32 12, ; 194
	i32 51, ; 195
	i32 62, ; 196
	i32 81, ; 197
	i32 126, ; 198
	i32 67, ; 199
	i32 7, ; 200
	i32 113, ; 201
	i32 72, ; 202
	i32 57, ; 203
	i32 82, ; 204
	i32 24, ; 205
	i32 123, ; 206
	i32 70, ; 207
	i32 131, ; 208
	i32 84, ; 209
	i32 3, ; 210
	i32 52, ; 211
	i32 39, ; 212
	i32 129, ; 213
	i32 11, ; 214
	i32 99, ; 215
	i32 59, ; 216
	i32 133, ; 217
	i32 24, ; 218
	i32 23, ; 219
	i32 123, ; 220
	i32 52, ; 221
	i32 31, ; 222
	i32 109, ; 223
	i32 53, ; 224
	i32 76, ; 225
	i32 28, ; 226
	i32 81, ; 227
	i32 38, ; 228
	i32 133, ; 229
	i32 66, ; 230
	i32 33, ; 231
	i32 80, ; 232
	i32 51, ; 233
	i32 102, ; 234
	i32 68, ; 235
	i32 95, ; 236
	i32 96, ; 237
	i32 121, ; 238
	i32 40, ; 239
	i32 118, ; 240
	i32 56, ; 241
	i32 32, ; 242
	i32 94, ; 243
	i32 70, ; 244
	i32 127, ; 245
	i32 83, ; 246
	i32 64, ; 247
	i32 27, ; 248
	i32 9, ; 249
	i32 103, ; 250
	i32 110, ; 251
	i32 46, ; 252
	i32 126, ; 253
	i32 48, ; 254
	i32 105, ; 255
	i32 116, ; 256
	i32 22, ; 257
	i32 93, ; 258
	i32 17, ; 259
	i32 39, ; 260
	i32 29, ; 261
	i32 78, ; 262
	i32 36, ; 263
	i32 102, ; 264
	i32 45, ; 265
	i32 35, ; 266
	i32 78 ; 267
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ 82d8938cf80f6d5fa6c28529ddfbdb753d805ab4"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
