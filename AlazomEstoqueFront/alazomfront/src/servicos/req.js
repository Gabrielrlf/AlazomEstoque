import axios from 'axios'

const url = "https://localhost:44342/";
class Req {

    alterarMaisVagas  = (ativo) => {
        return axios.post(`${url}Home/AlterarVaga/${ativo}`);
    }

    enviarCadForn = (obj) => {
        return axios.post(`${url}Home/EnviarInfoForn`, JSON.stringify(obj), {
            headers: {
                'Content-Type': "application/json",
            },
        });
    }
}

export default new Req();
