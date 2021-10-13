import axios from 'axios'

const url = "https://localhost:44342/";
class Req {

    alterarMaisVagas  = (ativo) => {
        return axios.post(`${url}Home/AlterarVaga/${ativo}`);
    }
}

export default new Req();
