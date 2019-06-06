import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import ListarCadastar from './pages/ListarCadastrar';
import { usuarioAutenticado } from './services/auth';

import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';
import * as serviceWorker from './serviceWorker';

//Altera o comportamento das routes
//converte component para Component porque dá problema declarar como minúsculo
const Permissao = ({component : Component}) => (
    <Route
        render = {props => usuarioAutenticado() ? 
            (<Component {...props } />) :
            (<Redirect to={{ pathname : "/listarcadastrar", state : {from: props.location}}} /> ) //se não estiver autenticado, redireciona para a página do login
        }
    />
); 

const rotas = (
    <Router>
        <div>
           <Switch>
                <Route exact path="/" component={ListarCadastar} />

           </Switch>
        </div>
    </Router>
);

//Se você tentar acessar o tiposeventos direto, sem estar logado, vai ser direcionado para a página de login. Contudo, isso, sozinho, não protege contra entradas não autorizadas.

ReactDOM.render(rotas, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
