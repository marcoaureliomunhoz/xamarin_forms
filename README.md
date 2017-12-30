# Xamarin Forms

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