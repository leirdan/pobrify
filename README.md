
<!-- @import "[TOC]" {cmd="toc" depthFrom=1 depthTo=6 orderedList=false} -->

<!-- code_chunk_output -->

- [STRINGS](#centerstringscenter)
  - [1. Definição](#1-definição)
  - [2. Substring](#2-substring)
  - [3. Métodos de Strings](#3-métodos-de-strings)
    - [3.1. Substring()](#31-substring)
    - [3.2. IndexOf()](#32-indexof)
    - [3.3. IsNullOrEmpty()](#33-isnullorempty)
    - [3.4. Split()](#34-split)
    - [3.5. Remove()](#35-remove)

<!-- /code_chunk_output -->

## <center>STRINGS</center>
### 1. Definição
*Strings* são nada mais que cadeias de caracteres de diversos tipos, desde alfabéticos até numéricos e com outros símbolos, as quais representam palavras, frases e textos em um programa. 

### 2. Substring
Uma string pode ser subdividida na forma de *substrings*, pequenos trechos da string que podem conter informações valiosas para o programa, como a url de um vídeo, por exemplo.

### 3. Métodos de Strings

#### 3.1. Substring()
Recebe como argumento a posição do caractere de onde será iniciado o particionamento da string em substrings. Tal método retorna uma nova substring, ou seja, não altera a string original, por isso é necessário armazenar seu valor em uma variável. É um método *inclusivo*, ou seja, retorna também o caractere de onde começa a contagem.

#### 3.2. IndexOf()
Recebe como argumento o caractere que deseja encontrar em uma string e retorna o índice (número inteiro) da primeira ocorrência desse caractere.
Existem diversas sobrecargas desse método; em uma destas é possível também obter o primeiro caractere onde uma determinada palavra inicia.

#### 3.3. IsNullOrEmpty()
Método estático (acessível diretamente a partir do tipo `String`) que verifica se uma string é vazia ou nula e retorna um booleano com base nisso.
> Nota acerca da palavra string: não há diferença entre usar "string" e "String" no .NET, visto que "string" é uma palavra-chave reservada que faz referência à classe String. Ou seja, não há diferença entre `String nome = "Gehenna"` e `string nome = "Gehenna"`.

#### 3.4. Split()
Recebe como argumento um caractere separador, e retorna um array de substrings separadas com base nesse caractere específico.
#### 3.5. Remove()
Recebe como parâmetro uma posição na string e uma quantidade de caracteres (opcional) e retorna uma nova string sem os caracteres a partir da posição informada até o fim (ou até atingir a quantidade informada).

#### 3.6. ToUpper() - ToLower()
Método invocado em um objeto que retorna a string original em caixa alta (ToUpper) ou caixa baixa (ToLower).

#### 3.7. Contains()
Método que verifica se uma string contém uma determinada substring, e retorna um booleano como resposta.
