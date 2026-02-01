# Chat IA Educacional

Projeto de demonstração de integração com APIs de IA, desenvolvido em ASP.NET Core Razor Pages. O objetivo é auxiliar o aprendizado educacional, oferecendo uma experiência de chat interativa com recursos de voz, temas personalizáveis e integração com modelos de IA.

## Funcionalidades

- **Chat em tempo real** com SignalR
- **Integração com OpenAI** (GPT-4o-mini)
- **Síntese de voz** (ElevenLabs e Web Speech API)
- **Reconhecimento de voz** (Web Speech API)
- **Temas personalizáveis** (6 paletas de cores)
- **Seleção de cursos, disciplinas e tópicos**
- **Contador de usuários online**
- **Interface responsiva e moderna**

## Tecnologias Utilizadas

- ASP.NET Core Razor Pages (.NET 9)
- C#
- SignalR
- OpenAI API
- ElevenLabs API
- JavaScript (ES6+)
- HTML5/CSS3
- Web Speech API

## Como Executar

1. **Clone o repositório:**
```sh
git clone https://github.com/YuriLucka/Chat-IA.git
```

2. **Configure as chaves de API:**
   - Edite o arquivo `Robo/appsettings.json` e insira suas chaves das APIs OpenAI e ElevenLabs.

3. **Restaure os pacotes e execute o projeto:**
```sh
dotnet restore
   dotnet run --project Robo/Robo.csproj
```

4. **Acesse no navegador:**
```
http://localhost:5000
```

## Estrutura do Projeto

- `Robo/` - Projeto principal Razor Pages
- `Robo/Views/` - Views Razor (HTML/CSS/JS)
- `Robo/appsettings.json` - Configurações e chaves de API
- `wwwroot/js/cursos.json` - Estrutura de cursos, disciplinas e tópicos

## Observações

- O modelo GPT-4o-mini pode apresentar respostas inesperadas (alucinações).
- O reconhecimento e síntese de voz dependem do suporte do navegador.
- O projeto é para fins educacionais e demonstração.

## Autor

- Yuri L C Rodrigues  
  [LinkedIn](https://www.linkedin.com/in/yuri-lucka-4a08a4197/)
