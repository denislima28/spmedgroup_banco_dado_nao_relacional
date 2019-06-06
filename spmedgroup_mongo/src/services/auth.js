export const usuarioAutenticado = () => localStorage.getItem('usuario_mongospmedgroup') !== null; //verifica se usuário está autenticado


//Junto com o código no app.js, vai servir para verificar o tipo de usuário.
export const parseJwt = () =>{
  var base64Url = localStorage.getItem("usuario_mongospmedgroup").split('.')[1];
  var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  
  return JSON.parse(window.atob(base64));
}