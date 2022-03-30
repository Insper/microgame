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
+---Packages
\---ProjectSettings
```

Este projeto conta com três classes base, **que não devem ser alteradas**.

A cena inicial/final já vem configurada com o ID 0 no build settings. Não altere a ordem pois será usada para iniciar e finalizar o jogo como um todo.

**GameManager.cs** Gerência o jogo como um todo, responsável pelas trocas de cenas e finalização do mesmo.

**BaseMGController.cs** Classe abstrata que devera ser herdada pelo controlador do seu microgame. Responsavel por instanciar o GameManager bem como registrar e remover os eventos definidos por ele.

Conta também com 3 Métodos que devem ser implementados:
> **StartMicrogame()** Após carregada a cena de seu microgame esse método será chamado para iniciar seu jogo (você pode passar instruções).
>
> **Microgame()** Ao final da intrução esse método é chamado para executar o jogo principal.
>
> **EndMicrogame()** Ao final do tempo de execução esse método é chamado para o feedback de finalização bem ou mal succedida do jogo.

Exemplo de classe Controller do microgame

```csharp
public class NomeController : BaseMGController
{
    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");
    }

    protected override void Microgame()
    {
        Debug.Log("Jogo Principal");
    }

    protected override void EndMicrogame()
    {
        Debug.Log("Jogo Acabou");
    }

    private void LateUpdate()
    {
        //Logica do seu jogo
    }

}
```

Existem também 2 *prefabs* importantes na pasta ressources:

**Canvas** onde residem os sliders que funcionam como barra de tempo.

**GameManager** é o GameObject em que reside o Script do GameManager, ele é instanciado automaticamente pelo awake do `BaseMGController`.

### Entrega (Pull Request)

Para que seu pull request seja aceito, e consequentemente entregue você deverá criar uma pasta com o formato `NomeSobrenome` dentro da pasta Microjogos. E todas suas adições ao projeto devem estar contidas nesta pasta.

Para os assets que for criar adicione um prefixo com as iniciais de seu nome, para evitar colisão de nomes com colegas.

Exemplo
```
Microjogos
|   +---PedroEmil
|   |   +---scenes
|   |   |       phepf_Cena01.unity
|   |   \---scripts
|   |           phepf_Controller.cs
```

Pull requests fora desse formato **Não serão aceitos**
