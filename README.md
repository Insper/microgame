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
|   +---Internal
|   |       BaseMGController.cs
|   |       GameData.cs
|   |       GameManager.cs
|   |
|   +---Microjogos
|   |   +---LucianoSoares
|   |   |   +---scenes
|   |   |   \---scripts
|   |   |
|   |   +---PedroEmil
|   |   |   +---scenes
|   |   |   |       phepf_Cena01.unity
|   |   |   \---scripts
|   |   |           phepf_Controller.cs
|   |   |
|   |   \---WillianLima
|   |       +---scenes
|   |       \---scripts
|   |
|   +---Resources
|   |       Canvas.prefab
|   |       GameManager.prefab
|   |       Main Camera.prefab
|   \---Scenes
|           EndGame.unity
|           StartGame.unity
+---Packages
\---ProjectSettings
```

Este projeto conta com três classes base, **que não devem ser alteradas**.

**GameData.cs** Controla os status do jogo.

**GameManager.cs** Gerência o jogo como um todo, responsável pelas trocas de cenas e finalização do mesmo.

**BaseMGController.cs** Classe abstrata que devera ser herdada pelo controlador do seu microgame. Responsavel por instanciar o GameManager bem como registrar e remover os eventos definidos por ele.

Conta também com 3 Métodos que devem ser implementados:
> **StartMicrogame()** Após carregada a cena de seu microgame esse método será chamado para iniciar de fato seu jogo.
>
> **WinMicrogame()** Ao final do tempo de execução esse método é chamado para o feedback de finalização bem succedida do jogo.
>
> **EndMicrogame()** Ao final do tempo de execução esse método é chamado para o feedback de finalização mal succedida do jogo.

Exemplo de classe Controller do microgame

```csharp
public class NomeController : BaseMGController
{
    protected override void StartMicrogame()
    {
        Debug.Log("Inicio do Jogo");
    }

    protected override void WinMicrogame()
    {
        Debug.Log("Jogador Ganhou");
    }

    protected override void EndMicrogame()
    {
        Debug.Log("Jogador Perdeu");
    }

    private void LateUpdate()
    {
        //Logica do meu jogo
    }

}
```

Existem também 2 *prefabs* importantes na pasta ressources:

**Canvas**

**GameManager**

### Entrega (Pull Request)

Para que seu pull request seja aceito, e consequentemente entregue você deverá criar uma pasta com o formato `NomeSobrenome` dentro de Microjogos. E todas suas adições ao projeto devem estar contidas nesta pasta.

Para os assets que for criar adicione um prefixo com as iniciais de seu nome, para evitar colisão de nomes com colegas.

```
Microjogos
|   +---PedroEmil
|   |   +---scenes
|   |   |       phepf_Cena01.unity
|   |   \---scripts
|   |           phepf_Controller.cs
```

Pull requests fora desse formato **Não serão aceitos**