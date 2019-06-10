import React, { Component } from 'react';
import Axios from 'axios';

class Login extends Component {
    constructor()
    {
      super();

      this.state ={
        email : '',
        senha : ''
      }
    }


    atualizaEstado(event){
        this.setState({[event.target.name] : event.target.value});
    } //colocando name nos inputs, não é preciso criar um método de atualização para cada um.
      //Um único para todos já vai bastar.

    fazerLogin(event){
        event.preventDefault();

        Axios.post('http://192.168.3.70:5000/api/loginmongo', {
            email : this.state.email,
            senha: this.state.senha
        })
        .then(data => {
            console.log(data);
            localStorage.setItem("usuario_mongospmedgroup", data.data.token); //Gravar o token
        
            //comando para mandar para a página "listarcadastrar" quando fizer o login
            this.props.history.push('/listarcadastrar');
        })
        .catch(erro => {
            this.setState({ erroMensagem : 'Email e/ou senha inválidoS'});
        })
    }

    render() {
        return (

            <main className="login_mongo">
                <form onSubmit={this.fazerLogin.bind(this)}>
                    <div>Email <input
                                placeholder="Digite seu e-mail" 
                                value={this.state.email} 
                                type="text"
                                onChange={this.atualizaEstado.bind(this)}
                                name="email"/>
                    </div>

                    <div>Senha <input 
                                placeholder="Digite sua senha"
                                value={this.state.senha} 
                                type="text"
                                onChange={this.atualizaEstado.bind(this)}
                                name="senha"/>
                    </div>

                    <button type="submit" className="botao_login">ENTRAR</button>

                </form>

            </main>
        );
    }
    
}

export default Login;