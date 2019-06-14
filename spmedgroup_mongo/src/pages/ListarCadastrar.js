import React, { Component } from 'react';
import Axios from 'axios';
import { Map, GoogleApiWrapper, InfoWindow, Marker } from 'google-maps-react';

const mapStyles = {
    width: '70%',
    height: '70%'
  };


class ListarCadastrar extends Component{ 
    
    state = {
    showingInfoWindow: false,  //Hides or the shows the infoWindow
    activeMarker: {},          //Shows the active marker upon click
    selectedPlace: {}          //Shows the infoWindow to the selected place upon a marker
      };

      onMarkerClick = (props, marker, e) =>
      this.setState({
        selectedPlace: props,
        activeMarker: marker,
        showingInfoWindow: true
      });
  
    onClose = props => {
      if (this.state.showingInfoWindow) {
        this.setState({
          showingInfoWindow: false,
          activeMarker: null
        });
      }
    };  

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
            headers: {
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + localStorage.getItem('usuario_mongospmedgroup')
            }
        }
        )
   
        //TENTATIVA MAL SUCEDIDA EM ATUALIZAR A TELA EM TEMPO REAL
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

    //ainda precisa ser melhorado 
    // mostrarLocalizacoesGoogle(){
    //     Axios.get('http://192.168.3.70:5000/api/usuariosmongo',
    //     {
    //         headers: {
    //           'Content-Type': 'application/json',
    //           'Authorization': 'Bearer ' + localStorage.getItem('usuario_mongospmedgroup')
    //         } 
    //     }
    //     )       

        

    // }

    atualizaEstado(event){
        this.setState({[event.target.name] : event.target.value});
    } //colocando name nos inputs, não é preciso criar um método de atualização para cada um.
      //Um único para todos já vai bastar.
    
    
    //O cadastro funciona. Contudo, assim que o cadastro é feito, aparece uma
    //tela de erro. Se a página for atualizada, o registro cadastrado, assim
    //como todos os que já estavam no banco, é listado.
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
            headers: {
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + localStorage.getItem('usuario_mongospmedgroup')
            } 
        }
        )
        .then(res => {
            let usuariosmongo = res.data;
            this.setState({ lista_usuariosmongo : usuariosmongo});
            alert("Especialidade do médico e endereço do paciente foram cadastrados.");
            //o alerta ainda não funciona.
        }).catch((erro) => {
            console.log('erro', erro)
        })  
        
        console.log(usuariosmongo);
    }

    render() {

        return (
            <main className="usuariosmongo_listar">

                
<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAgl5jcqJtDQiMBEvVkd_QLRQxeHyKP1so&callback=initMap"
  type="text/javascript"></script>


                <h2>Listagem de usuários</h2>

                <div>

                    <table id="lista_usuarios_mongo">
                        <thead>
                            <tr>
                            <th>#</th>
                            <th>Email</th>
                            <th>Tipo de usuário</th>
                            <th>Especialidade do médico</th>
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
                                        value={this.state.email} 
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

                            <div>Especialidade do médico<input 
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

                
        {/* Código do mapa e marcador do ponto central */}
        {/* Arranjar uma maneira de fazer o mapa mostrar a latitude e longitude guardadas no banco */}       
                <Map
                    google={this.props.google}
                    zoom={14}
                    style={mapStyles}
                    initialCenter={{
                    lat: 23.9988442,
                    lng: 88.6455588
                    }}>
                    <Marker
                    onClick={this.onMarkerClick}
                    />
                    <InfoWindow
                    marker={this.state.activeMarker}
                    visible={this.state.showingInfoWindow}
                    onClose={this.onClose}>
                         
                    </InfoWindow>                    
                </Map>      


            </main>
        );
    }

    

}

export default GoogleApiWrapper({
    apiKey: 'AIzaSyAgl5jcqJtDQiMBEvVkd_QLRQxeHyKP1so' 
  })(ListarCadastrar);

//Além de fazer o código e pegar a chave, também é necessário ir até o google cloud
//e habilitar o acesso ao Google Maps. Do contrário, o mapa não aparece.

//Este link pode ajudar com o mapa: https://scotch.io/tutorials/react-apps-with-the-google-maps-api-and-google-maps-react