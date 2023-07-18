## Audissey - Media Player
<img src="https://github.com/andavgc/WPF-music-player/assets/108239558/cae23ebe-227d-4905-82cc-50e590d95eb1" 
      alt="Audissey Layout" 
      align=center 
      style="display: block;
            margin-left: auto;
            margin-right: auto;"
/>

**Audissey** é um reprodutor de midia desenvolvido durante a disciplina de **Desenvolvimento de Interface de Usuário do curso Tecnologias Microsoft - Extecamp (Universidade Estadual de Campinas)**. 
Ele possui um layout simples que permite as seguintes ações:
- Reproduzir
- Pausar a reprodução
- Pular para o próximo arquivo
- Voltar ao arquivo anterior
- Manipular o volume
- Adiantar ou retroceder a reprodução
- Escolher um arquivo específico para reproduzir


### Detalhes de implementação:

O aplicativo foi desenvolvido com WPF, seguindo os guidelines da Microsoft, foram criadas 3 classes principais que interagem entre si:
- **MainWindow**: que representa o layout principal, ele possui metodos os métodos básicos PlaySong, StopSong, NextSong, PreviousSong e ChangeVolume assim como outros métodos um pouco mais complexos:
  - **OpenFile**: Abre uma janela no diretório atual e permite escolher um arquivo para ser reproduzido, também chama o método OpenSong que cria uma novo objeto da classe SongList com os arquivos dentro do diretório que o arquivo selecionado se encontra
  - **OpenSong**: Depois de selecionar o arquivo, esse método é o que de fato abre o arquivo, colhe suas informações para criar o SongList e o objeto Song do arquivo atual, e da início à reprodução.
  - **TimerTick**: Esse método é responsável por colher as informações da arquivo sendo reproduzido e atualizar o minuto atual do arquivo assim como sua duração total.
  - **TimeLapseModification**: Modifica a posição da barra de reprodução em relação ao tempo transcorrido da reprodução.
  - **positionSliderSkip**: Permite a modificação do tempo de reprodução fazendo click na barra de reprodução.
- **SongList**: que contêm um array de objetos da classe Song dos arquivos dentro do diretório atual e cria uma fila a ser reproduzida 
- **Song**: que contêm as informações de título e duração do arquivo de mídia.

### Compilando Jewel Collector
Audissey está disponível unicamente para Windows. Para compilar o programa, primeiro é necessário ter feito o download e instalado o [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) localmente.
Com  isso, basta baixar o programa e executá-lo utilizando o `dotnet run`.
```shell
git clone https://github.com/andavgc/WPF-music-player.git
dotnet run
```

### Colaboradores
- [Antony Valete](https://github.com/AntonyValete)
- [Andrés Garica](https://github.com/andavgc)
- [Lucas Mellone](https://github.com/lknknm)

### License
> This project is licensed under the GNU Affero General Public License v3.0. 
>
> Friendly reminder: Due to academic honesty terms of your institution, it is NOT recommended to use this project under academic organizations to complete assignments.
