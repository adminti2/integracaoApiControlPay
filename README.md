# Aplicação de exemplo para APIs ControlPay

Esta é uma aplicação de exemplo de como se integrar a algumas APIs do ControlPay.
Para mais informações sobre o ControlPay, suas APIs e modo de funcionamento, acesse <a href=https://paygodev.readme.io/docs/o-que-é-controlpay target="_blank">a documentação do ControlPay</a>.

## Pré-requisitos

Para usar esta aplicação, o usuário deve ter sua conta criada no ambiente de sandbox do ControlPay. Lá ele deve ter um terminal pronto para transacionar (configurado e vinculado a um ponto de captura), além de ter sua conta configurada para permitir vendas.

Caso ainda não tenham sido feitas e precise que estas configurações sejam realizadas, entre em contato com nosso time de relacionamento com o desenvolvedor.

## Duas versões

A aplicação de exemplo neste repositório se encontra em duas versões: uma em HTML/CSS/Javascript e uma em C#/WinForms. Ambas funcionam do mesmo modo e com as mesmas APIs, podendo o usuário escolher entre qual prefere usar.

## Chamadas de APIs

Em ambas as aplicações, as chamadas podem ser visualizadas pelo usuário e estudadas usando as peculiaridades de cada linguagem.

As chamadas feitas em Javascript podem ser visualizadas usando as ferramentas do desenvolvedor (DevTools) do navegador, usando o console e a aba "Network"/"Rede".

As chamadas realizadas em C# podem ser vizualizadas na janela de output quando a aplicação é rodada no modo debug.

## TEF

Caso o usuário pretenda realizar transações TEF com a aplicação de exemplo, é necessário que um PayGo Windows esteja instalado e funcionando (para que as transações possam ser direcionadas a este.)

## Gateway

Caso o usuário pretenda realizar transações Gateway, é necessário ter suas credenciais do Gateway PayGo configuradas no ControlPay.
