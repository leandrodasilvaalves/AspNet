#language: pt-br

Funcionalidade: Cadastro de Usuarios
	EU ENQUANTO usuario
	QUERO me registrar
	E me logar
	PARA ter acesso completo do sistema

Cenário: 1. [Chrome] Cadastrar usuario no banco de dados
	Dado usuario se encontra na pagina de registro
	| Email             | Password  | ConfirmPassword | Browser |
	| leandro@gmail.com | 123@Mudar | 123@Mudar       | Chrome  |
	Quando clicar no botao Register
	Então o usuario será autenticado

Cenário: 1. [Firefox] Cadastrar usuario no banco de dados
	Dado usuario se encontra na pagina de registro
	| Email             | Password  | ConfirmPassword | Browser |
	| leandro@gmail.com | 123@Mudar | 123@Mudar       | Firefox  |
	Quando clicar no botao Register
	Então o usuario será autenticado

Cenário: 1. [IE] Cadastrar usuario no banco de dados
	Dado usuario se encontra na pagina de registro
	| Email             | Password  | ConfirmPassword | Browser |
	| leandro@gmail.com | 123@Mudar | 123@Mudar       | IE  |
	Quando clicar no botao Register
	Então o usuario será autenticado


Cenário: 2. [Chrome] Logar no banco de dados
	Dado usuario se encontra na pagina de login
	| Email             | Password  | Browser |
	| leandro@gmail.com | 123@Mudar | Chrome  |
	Quando clicar no botao login
	Então o usuario será autenticado

Cenário: 2. [Firefox] Logar no banco de dados
	Dado usuario se encontra na pagina de login
	| Email             | Password  | Browser |
	| leandro@gmail.com | 123@Mudar | Firefox |
	Quando clicar no botao login
	Então o usuario será autenticado

Cenário: 2. [IE] Logar no banco de dados
	Dado usuario se encontra na pagina de login
	| Email             | Password  | Browser |
	| leandro@gmail.com | 123@Mudar | IE	  |
	Quando clicar no botao login
	Então o usuario será autenticado

