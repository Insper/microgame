# Missão Microgame

### Sobre o repositório
Neste reposiório você encontra o projeto base para a execução da missão do Microgame.

Você deverá criar um **fork** deste repositório e ao final do seu trabalho criar um Pull Request com suas alterações.

### Estutura do projeto.

```
microgame
|   README.md
|
+---Assets
|   |
|   +---MicrogameInternal
|   |   MainMenu.unity
|   |   |   +---Sprites
|   |   |       timer.png
|   |   |   \---Scripts
|   |   |       CountdownTimer.cs
|   |   |       Teste.cs
|   |   |       GameManager.cs
|   |
|   +---Microjogos
|   |   +---<!CRIE UMA PASTA COM SEU NOME!>
|   |   |   +---scenes
|   |   |   \---scripts
|   |   |
|   +---Resources
|   |       Canvas.prefab
|   |       GameManager.prefab
|   \---Scenes
|           MainScene.unity
+---Packages
\---ProjectSettings
```

Este projeto conta com três classes base, **que não devem ser alteradas**.

A cena inicial/final já vem configurada com o ID 0 no build settings. Não altere a ordem pois será usada para iniciar e finalizar o jogo como um todo.

**ConuntdownTimer.cs** Controla a UI e tempo de jogo.

**GameManager.cs** Gerência o jogo como um todo, responsável pelas trocas de cenas e finalização do mesmo.

**Teste.cs** Utilize essa classe para testar seu game loop. Insira em qualquer GameObject da sua cena e você terá acesso aos menus de contexto (TesteInicio e TesteJogoPerdido).

Existem também 1 *prefab* importante na pasta ressources:

**countDownUI** onde residem os sliders que funcionam como barra de tempo.

### Entrega (Pull Request)

Para que seu pull request seja aceito, e consequentemente entregue você deverá criar uma pasta com o formato `NomeSobrenome` dentro da pasta Microjogos. E todas suas adições ao projeto devem estar contidas nesta pasta.

Para os assets que for criar adicione um prefixo com as iniciais de seu nome, para evitar colisão de nomes com colegas.

Exemplo
```
Assets
|   +---PedroEmil
|   |   +---scenes
|   |   |       phepf_Cena01.unity
|   |   \---scripts
|   |           phepf_Controller.cs
```

Pull requests fora desse formato **Não serão aceitos**
