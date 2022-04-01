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
|   +---MicrogrameInternal
|   |       CountdownTimer.cs
|   |       Teste.cs
|   |       Inicio.cs
|   |       GameManager.cs
|   |
|   +---<!CRIE UMA PASTA COM SEU NOME E SOBRENOME!>
|   |   +---scenes
|   |   \---scripts
|   |
|   +---Resources
|   |       countdownUI.prefab
|   |
|   \---Scenes
|           MainScene.unity
|
+---Packages
\---ProjectSettings
```

Este projeto conta com classes base, **que não devem ser alteradas**.

A cena inicial/final já vem configurada com o ID 0 no build settings. Não altere a ordem pois será usada para iniciar e finalizar o jogo como um todo.

**GameManager.cs** Gerência o jogo como um todo, responsável pelas trocas de cenas e finalização do mesmo.

**CountdownTimer.cs** Classe que faz a animação da barra de tempo.

**Inicio.cs** Classe para iniciar o jogo na cena principal.

**Teste.cs** Classe para realizar testes dos jogos.

no GameManager você conta com:
> **ActiveLevel** O nível da fase que você se encontra.
> **GameLost()** Ao final do tempo de execução esse método é chamado para o feedback de finalização mal succedida do jogo.

Exemplo de classe Controller do microgame

### Entrega (Pull Request)

Para que seu pull request seja aceito, e consequentemente entregue você deverá criar uma pasta com o formato `NomeSobrenome` dentro da pasta Microjogos. E todas suas adições ao projeto devem estar contidas nesta pasta.

Para os assets que for criar adicione um prefixo com as iniciais de seu nome, para evitar colisão de nomes com colegas.

Exemplo
```
Assets
|   +---Emil
|   |   +---scenes
|   |   |       phepf_Cena01.unity
|   |   \---scripts
|   |           phepf_Controller.cs
|   +---LucianoSoares
|   |   +---scenes
|   |   \---scripts
|   |

```

Pull requests fora desse formato **Não serão aceitos**
