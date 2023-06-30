
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
    - [3.6. ToUpper() - ToLower()](#36-toupper---tolower)
    - [3.7. Contains()](#37-contains)
- [ REGEX ](#center-regex-center)
- [ ARRAYS E TIPOS GENÉRICOS ](#center-arrays-e-tipos-genéricos-center)
  - [1. Definição](#1-definição-1)
  - [2. Iteração com comprimento do array](#2-iteração-com-comprimento-do-array)

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


## <center> REGEX </center>

Expressões regulares (abreviadas comumente como **Regex**) são sequências de caracteres extremamente úteis para identificar padrões em strings e buscar dados, como CPFs, números de telefone e outros. Vamos montar de exemplo um Regex para identificar um número de telefone:
Temos que o número terá 9 caracteres e um hífen os separando, no formato *XXXXX-XXXX*. Assim, temos inicialmente, para cada caractere, a possibilidade de dígitos `[0123456789]`, e no 6º caractere, o único dígito `[-]`.
```cs
string pattern = "[0-9][0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
string text = "99953-2891";
Console.WriteLine(Regex.IsMatch(text, pattern)); // verifica se uma parte da string bate com o padrão regular, e retorna true nesse caso.
```

É possível encurtar o padrão usando *quantificadores* da seguinte forma:
```cs
// as {} indicam o número de vezes que o grupo de caracteres se repete, ou seja, os quantificadores; o primeiro par de {} indica que o padrão se repete de 4 a 5 vezes (para englobar os telefones e também números de celulares)
string pattern = "[0-9]{4,5}[-][0-9]{4}";
```

Para casos onde o número vem sem o hífen, podemos melhorar:
```cs
string pattern = "[0-9]{4,5}-{0,1}[0-9]{4}"; // removemos os colchetes no hífen pois é somente um caractere.
```

É possível substituir esse {0, 1} por um "?":
```cs
string pattern = "[0-9]{4,5}-?[0-9]{4}";
```

Pronto, temos uma regex básica para capturar um número de telefone.

## <center> ARRAYS E TIPOS GENÉRICOS </center>

### 1. Definição
*Arrays* são coleções de dados do mesmo tipo em uma variável só. Para declarar um array, deve-se informar o tipo do array, indicar que é uma coleção a partir das `[]`, nomear o array e construí-lo. Por exemplo, temos:
```cs
string[] songs = new string[5];
songs[0] = "in the dark"; // atribuição de valor para um array
```

É possível acessar um valor de um array a partir de seu índice, como em `songs[0]`, que retorna a string "in the dark".

### 2. Iteração com comprimento do array
Acessando manualmente um índice de um array para descobrir o seu valor, é necessário escrever todas as possibilidades de índices que o array tem, como `songs[1]`, `songs[2]`, `songs[3]` e `songs[4]`. Ao invés disso, é possível utilizar da propriedade **length** (representa o comprimento do array) e acessar os valores em um laço de repetição, como em:
```cs
 // Declara um array com um tamanho fixo
string[] songs = new string[5];
songs[0] = "in the dark";
songs[1] = "drugs and love";
songs[2] = "a blaze in the northern sky";
songs[3] = "the deathless sun";
songs[4] = "it's nice to have a friend";

Console.WriteLine("fav songs:");
for (int i = 0; i < songs.Length; i++)
{
  // Acessa o índice do array e imprime cada um de seus valores de forma dinâmica
    Console.WriteLine(" - " + songs[i]);
}
```

É possível também utilizar um laço de repetição para inicializar um array, como em:
```cs
Console.Write("insert the limit of albums: ");
int limit = Convert.ToInt32(Console.ReadLine());
string[] albums = new string[limit];
// Inicializando os elementos do array com base nas entradas do usuário
for (int j = 0; j < limit; j++)
{
    var a = Console.ReadLine();
    albums[j] = a;
};
// Exibindo os elementos inseridos pelo usuário
Console.WriteLine("favorite albums are:" );
for (int k = 0; k < albums.Length;  k++)
{
    Console.WriteLine(albums[k]);
}

Console.ReadLine();
```

Uma forma simplificada de inicializar manualmente o array também é por meio de: 
```cs
string[] songs = new string[]
{
    "in the dark", // indice 0
    "drugs and love", // indice 1
    "a blaze in the northern sky",
    "the deathless sun",
    "it's nice to have a friend"
};
```