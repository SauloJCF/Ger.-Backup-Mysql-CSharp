Este é um programa simples que permite gerar dumps de um banco de dados mysql. 
O programa consulta o arquivo config.dat para conseguir as informações necessárias para realizar a conexão.
Caso o arquivo esteja vazio, ele pede ao usuário que entre com os dados, inclusive o local onde deseja ser salvo o arquivo.
Os dados salvos neste arquivo são criptografados através do AES, assim, não ficam explicitos para alteração.
É possivel mudar a chave e o IV do AES, dentro do arquivo Criptografia.cs.
