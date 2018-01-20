# Xamarin Forms

**Introdução** 

Xamarin Forms é um framework (biblioteca/pacote NuGet). Ele abstrai as diferenças de implementação de cada plataforma através mapeamentos.

Como se trata de um framework ele pode ser obtido/atualizado via NuGet. Geralmente a versão que acompanha as ferramentas como o Visual Studio é uma versão mais antiga, porém através do NuGet é possível fazer a atualização.

**Principais Elementos**

- Page (Páginas)
    - ContentPage
    - MasterDetailPage
    - NavigationPage
    - TabledPage
    - CarouselPage
- Layout
    - StackLayout
    - AbsoluteLayout
    - RelativeLayout
    - Grid
    - ScrollView
    - Frame
    - ContentView
- View (Controles)
    - Label
    - Image
    - Button
    - BoxView: retângulo gráfico colorido. Pode ser usado para inserir imagem ou outra view ou grupo de views mais complexos.
    - ListView
    - Entry: caixa de texto de uma única linha. Herda de _InputView_.
    - Editor
    - Picker
    - DatePicker
    - Stepper
    - Slider
    - Switch
    - ActivityIndicator
    - ProgressBar
- Application: classe base que fornece para _App_ os eventos de ciclo de vida _OnStart_, _OnSleep_ e _OnResume_.

**Navegação**

- **Gerenciadores de Navegação:**
    - **NavigationPage:** gerencia a navegação entre páginas.
        - Navigation.PushAsync(new MyContentPage()): insere uma página na pilha e nageva até ela. Como se trata de uma navegação hierarquica temos uma barra de navegação para voltar ou avançar na hierarquia.
        - Navigation.PopAsync(): tira uma página da pilha, ou seja, fecha uma página e volta para a anterior na hierarquia.
        - Navigation.PushModalAsync(new MyContentPageModal()): insere uma página na pilha e navega até ela. A diferença é que se trata de uma navegação "não hierárquica" e neste caso não temos a barra de navegação. Sendo assim o controle de fechamento da página (retirada da pilha) é de nossa responsabilidade.
        - Navigation.PopModalAsync(): tira uma página modal da pilha, ou seja, fecha a página e volta para a anterior.
    - **NavigationDrawer:** gaveta de navegação com o uso de MasterDetailPage.
    - **TabbedPage:** abas de navegação. No Android e no Windows Phone as abas ficam no topo e no iOS ficam na parte inferior.
    - **CarouselPage:** as páginas gerenciadas por CarouselPage rolam para fora da tela para revelar outra página quando o usuário realiza o deslizamento para um dos lados.
- **Gerenciando o Estado:**
    - **Na memória, passando o estado entre páginas:** podemos passar o estado de uma página para outra através do construtor.
    - **Na memória, aplicando o padrão Singleton + classe App:** podemos aplicar o padrão Singleton a objetos de estado e agregá-los à classe App (Application).
    - **Persistindo em disco através do dicionário Properties:** esse recurso é mais usado quando o sistema operacional tira a aplicação de cena levando ela para segundo plano e depois volta ela, ou seja, quando a aplicação desaparece (OnDisappearing) e depois de um tempo ela aparece (OnAppearing). 
        - Salvando: Application.Current.Properties["id"] = 123;
        - Recuperando: int id = (int) Application.Current.Properties["id"];

**Vinculação a Dados**

- Temos duas opções:
    - Vinculação a dados trivial: alterações na visão são refletidas automaticamente no modelo de dados, mas não o contrário.
        - Toda visão, inclusive uma página, possui uma propriedade chamada **BindingContext** e toda visão possui um método chamado **SetBinding**. É através de BindingContext que indicamos para a visão onde estão os dados e é através de SetBinding que indicamos para a visão qual propriedade do modelo deve ser atualizada.
        ````csharp
        //aqui temos a classe do modelo
        class MyModel {
            public string Property1 { get; set; }
            public int Property2 { get; set; } 
        }
        
        //aqui temos o modelo
        var myModel = new MyModel(); 
        
        //aqui temos duas caixas de texto e estamos indicando onde estão os dados no nível da visão
        myEntryView1.BindingContext = myModel;
        myEntryView2.BindingContext = myModel;
        
        //aqui temos uma outra forma de indicar onde estão os dados (no nível da página)  
        //this..BindingContext = myModel;
        
        //aqui estamos indicando para cada caixa de texto qual propriedade do modelo deve ser atualizada
        myEntryView1.SetBinding(Entry.TextProperty, "Property1");
        myEntryView2.SetBinding(Entry.TextProperty, "Property2");
        ````
    - Vinculação a dados não trivial: alterações na visão são refletidas automaticamente no modelo de dados e alterações no modelo de dados são refletidas automaticamente na visão. Porém para que esse mecanismo de mão dupla funcione precisamos implementar na classe de modelo a interface **INotifyPropertyChanged**. 
        > Essa escolha de vincular o modelo de dados diretamente com a visão não é muito indicada. Um padrão muito utilizado em xamarin é o MVVM onde temos a Visão (View), o Modelo de Dados (Model) e uma classe que fica no meio do caminho chamada de Modelo de Visão (ViewModel). Neste caso o modelo de dados não implementa INotifyPropertyChanged, a implementação fica no modelo de visão, a vinculação do modelo de visão ocorre no nível de página e as vinculações de propriedades de cada visão continuam sendo feitas com SetBinding.

**SQLite** 

Opções para acessar bases SQLite:
- Biblioteca ORM criada por "Frank A. Krueger": para fazer uso da biblioteca num projeto PCL temos que instalar a biblioteca em todos os projetos da solução e obter **SQLiteConnection** de cada projeto específico através da classe **DependencyService**.
- ADO.NET: onde usamos SQLiteCommand e SQLiteDataReader.

**Acessando APIs do Sistema Operacional Local**

Existem certas circunstâncias em que somos obrigados a usar APIs do sistema operacional local. Nestas circunstâncias, em soluções PCL/Standard, para que o projeto PCL utilize instâncias criadas a nível específico podemos usar injeção de dependência e em soluções de projetos compartilhados podemos usar _compilação condicional_.

**Acessando o Clipboard em soluções PCL/Standard através de DependencyService** 

Para acessar o Clipboard em soluções PCL/Standard temos que usar **Interface** de serviço, e injeção de dependência (**DependencyService**). 

- **1º Passo:** criar uma interface no projeto compartilhado.
    ```csharp
    namespace App.Core 
    {
        public interface IClipboardService 
        {
            void SetText(string text);
        }
    }
    ```
- **2º Passo:** implementar classes concretas para cada projeto específico.
    ```csharp
    //--- Projeto iOS ---
    [assembly: Dependency(typeof(ClipboardService_iOS))]
    namespace App.iOS 
    {
        public class ClipboardService_iOS : IClipboardService
        {
            public void SetText(string text) 
            {
                UIPasteboard clipboard = UIPasteboard.General;
                clipboard.String = text;
            }
        }
    }
    //--- Projeto Android ---
    [assembly: Dependency(typeof(ClipboardService_Droid))]
    namespace App.Droid 
    {
        public class ClipboardService_Droid : IClipboardService
        {
            public void SetText(string text) 
            {
                var clipboardManager = (ClipboardManager)Android.App.Application.Context.GetSystemService(Context.ClipboardService);

                ClipData clipData = ClipData.NewPlainText("title", text);

                clipboardManager.PrimaryClip = clipData;
            }
        }
    }
    ```    
- **3º Passo:** usar o recurso no code-behind do projeto compartilhado.
    ```csharp
    namespace App.Core 
    {
        public partial class MainPage : ContentPage 
        {
            public MainPage() 
            {  
                DependencyService.Get<IClipboardService>.SetText("blábláblá");
            }
        }
    }
    ```

**Animações**

É muito fácil promover animações em nossas visões usando Xamarin Forms. Todas as **Views** possuem métodos de extensão voltados para animação.

Exemplo:
```csharp
    //aplicando escala 0 em uma imagem durante 1 segundo
    imagem.ScaleTo(0, 1000);

    //aplicando escala 2x em uma imagem durante 1 segundo
    imagem.ScaleTo(2, 1000);

    //rotacionando uma imagem 360° durante 1 segundo
    imagem.RotateTo(360, 1000);

    //rotacionando uma imagem -360° durante 1 segundo
    imagem.RotateTo(-360, 1000);

    //combinando várias animações em paralelo
    await Task.WhenAll(
        imagem.ScaleTo(2, 1000), //2x em 1 segundo
        imagem.RotateTo(360, 1000) //360° em 1 segundo
    );    

    //cancelando animações para uma dada view
    ViewExtensions.CancelAnimations(imagem);
```

Mais exemplos: 
- https://developer.xamarin.com/guides/xamarin-forms/user-interface/animation/

**Plugins** 

Uma das formas de acessar os recursos físicos do dispositivo é usar injeção de serviço e para cada plataforma usar suas APIs específicas. 

Uma outra forma é usar **plugins** prontos. Os plugins abstraem toda a dificuldade de usar injeção de serviço. 

Mais informações: 
- https://developer.xamarin.com/guides/xamarin-forms/platform-features/plugins
- https://github.com/xamarin/XamarinComponents
- https://channel9.msdn.com/Blogs/MVP-VisualStudio-Dev/Useful-Plugins-for-Xamarin-Forms
- https://montemagno.com/tag/plugins

---

**Fontes** 

- https://developer.xamarin.com/guides/xamarin-forms/ (Xamarin)
- https://developer.xamarin.com/guides/xamarin-forms/platform-features/plugins (Xamarin)
- https://www.youtube.com/channel/UCe-f02uZgEXdHmHpC3loAQg (Xamarin)
- https://www.youtube.com/user/MicrosoftBrasil (Microsoft Brasil)
- https://www.youtube.com/channel/UCFaQBRaoHrAxcGoeY8E5jvQ (Monkey Nights)
- https://www.youtube.com/user/angelobelchior (Angelo Belchior)
- https://www.youtube.com/user/ata275 (Tiago Britto)