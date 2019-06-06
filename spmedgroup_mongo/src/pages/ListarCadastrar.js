import React, { Component } from 'react';
import Axios from 'axios';

class ListarCadastrar extends Component{
    constructor(){
        super();

        this.state={
            lista_usuariosmongo : [],
            email: '',
            tipo_usuario: '',
            especialidade: '',
            doenca: '',
            latitude: '',
            longitude: ''
        };
    } //O mesmo construtor vai ser usado para listar e cadastrar

    listarUsuarios(){
        Axios.get('http://192.168.3.70:5000/api/usuariosmongo',
        {
            // headers: {
            //   'Content-Type': 'application/json',
            //   'Authorization': 'Bearer ' + localStorage.getItem('usuario_mongospmedgroup')
            // } //comentado porque ainda não tem o login
        }
        )
   
        // .onSnapshot((usuariosmongo) => {
        //     let usuariosmongoArray = [];

        //     usuariosmongo.forEach((mongo) => {
        //         usuariosmongoArray.push({
        //             id: mongo.id,
        //             email: mongo.data().email,
        //             tipo_usuario: mongo.data().tipo_usuario,
        //             especialidade: mongo.data().especialidade,
        //             doenca: mongo.data().doenca,
        //             latitude: mongo.data().latitude,
        //             longitude: mongo.data().longitude
        //         })
        //     })

        //     this.setState({lista_usuariosmongo : usuariosmongoArray}, () =>{
        //         console.log(this.state.lista_usuariosmongo);
        //     })
        // })

        .then(res => {
            const usuariosmongo = res.data;
            this.setState({ lista_usuariosmongo : usuariosmongo});
        })      

    }

    componentDidMount(){
        this.listarUsuarios();
    }

    atualizaEstado(event){
        this.setState({[event.target.name] : event.target.value});
    } //colocando name nos inputs, não é preciso criar um método de atualização para cada um.
      //Um único para todos já vai bastar.
    
    
    cadastrarUsuarios(event){
        event.preventDefault();

        let usuariosmongo = {
            email: this.state.email,
            tipo_usuario: this.state.tipo_usuario,
            especialidade: this.state.especialidade,
            doenca: this.state.doenca,
            latitude: this.state.latitude,
            longitude: this.state.longitude
        }

        Axios.post('http://192.168.3.70:5000/api/usuariosmongo', usuariosmongo,
        {
            // headers: {
            //   'Content-Type': 'application/json',
            //   'Authorization': 'Bearer ' + localStorage.getItem('usuario_mongospmedgroup')
            // } //comentado porque ainda não tem o login
        }
        )
        .then(res => {
            let usuariosmongo = res.data;
            this.setState({ lista_usuariosmongo : usuariosmongo});
        })  
        
        console.log(usuariosmongo);
    }

    render() {
        return (

            <main className="usuariosmongo_listar">

                <h2>Listagem de usuários</h2>

                <div>

                    <table id="lista_usuarios_mongo">
                        <thead>
                            <tr>
                            <th>#</th>
                            <th>Email</th>
                            <th>Tipo de usuário</th>
                            <th>Especialidade</th>
                            <th>Doença</th>
                            <th>Latitude</th>
                            <th>Longitude</th>
                            </tr>
                        </thead>

                        <tbody id="tabela_lista_usuariosmongo">
                        {
                            this.state.lista_usuariosmongo.map((todos_usuariosmongo) => {
                                return(
                                    <tr key={todos_usuariosmongo.id}>
                                        <td>{todos_usuariosmongo.id}</td>
                                        <td>{todos_usuariosmongo.email}</td>
                                        <td>{todos_usuariosmongo.tipo_usuario}</td>
                                        <td>{todos_usuariosmongo.especialidade}</td>
                                        <td>{todos_usuariosmongo.doenca}</td>
                                        <td>{todos_usuariosmongo.latitude}</td>
                                        <td>{todos_usuariosmongo.longitude}</td>  
                                    </tr>
                                );
                            })


                        }
                        </tbody>


                    </table>

                </div>
                

                <h2>Cadastro de usuários</h2>
                        <form onSubmit={this.cadastrarUsuarios.bind(this)}>
                            <div>Email <input 
                                        value={this.state.titulo} 
                                        type="text"
                                        onChange={this.atualizaEstado.bind(this)}
                                        name="email"/>
                            </div>

                            <div>Tipo de usuário <input 
                                        value={this.state.tipo_usuario} 
                                        type="text"
                                        onChange={this.atualizaEstado.bind(this)}
                                        name="tipo_usuario"/>
                            </div>

                            <div>Especialidade <input 
                                        value={this.state.especialidade} 
                                        type="text"
                                        onChange={this.atualizaEstado.bind(this)}
                                        name="especialidade"/>
                            </div>

                            <div>Doença <input 
                                        value={this.state.doenca} 
                                        type="text"
                                        onChange={this.atualizaEstado.bind(this)}
                                        name="doenca"/>
                            </div>

                            <div>Latitude <input 
                                        value={this.state.latitude} 
                                        type="text"
                                        onChange={this.atualizaEstado.bind(this)}
                                        name="latitude"/>
                            </div>

                            <div>Longitude <input 
                                        value={this.state.longitude} 
                                        type="text"
                                        onChange={this.atualizaEstado.bind(this)}
                                        name="longitude"/>
                            </div>

                            <div><button type="submit">ENVIAR</button></div>

                        </form>

            </main>
        )
    }

    

}

export default ListarCadastrar;