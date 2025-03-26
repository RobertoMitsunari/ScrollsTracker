
<script>
import { reactive, ref } from 'vue';

export default {
    setup() {
        let imageBytes = ref(null);
        let imageUrl = ref(null);

        let obra = reactive({
            id: 0,
            titulo: '',
            descricao: '',
            totalCapitulos: 0,
            ultimoCapituloLido: 0,
            imagem: null
        });

        const handleFileUpload = (event) => {
                    const file = event.target.files[0];
                    if (!file) return;

                    imageUrl.value = URL.createObjectURL(file);
                    
                    const reader = new FileReader();
                    reader.readAsDataURL(file)

                    reader.onload = () => {
                        imageBytes.value = new Uint8Array(reader.result);
                        obra.imagem = reader.result.replace('data:', '').replace(/^.+,/, '');
                    };
                };

        const cadastrar = async (event) => {
            event.preventDefault();

            try {
                const response = await fetch('https://localhost:7071/api/ScrollsTracker/Obras', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(obra)
                });

                if (!response.ok) throw new Error(await response.text());

                const data = await response.json();
                console.log('Cadastro realizado com sucesso!', data);
            } catch (error) {
                console.error('Erro no cadastro:', error);
            }
        };

        return {
            obra,
            imageBytes,
            imageUrl,
            handleFileUpload,
            cadastrar
        };
    }
}

</script>

<template>
    <div class="cadastrar-container">
      <h1>Cadastrar</h1>
      <div class="form-box">
        <form @submit.prevent="cadastrar">
          <div class="mb-3">
            <label for="titulo" class="form-label">Título</label>
            <input v-model="obra.titulo" type="text" class="form-control" id="titulo">
          </div>
          <div class="mb-3">
            <label for="descricao" class="form-label">Descrição</label>
            <textarea v-model="obra.descricao" class="form-control" id="descricao" rows="3"></textarea>
          </div>
          <div class="mb-3">
            <label for="totalCapitulos" class="form-label">Total de Capítulos</label>
            <input v-model="obra.totalCapitulos" type="number" class="form-control" id="totalCapitulos">
          </div>
          <div class="mb-3">
            <label for="ultimoCapituloLido" class="form-label">Último Capítulo Lido</label>
            <input v-model="obra.ultimoCapituloLido" type="number" class="form-control" id="ultimoCapituloLido">
          </div>
          <div class="mb-3">
            <label for="imagem" class="form-label">Imagem</label>
            <input type="file" class="form-control" id="imagem" accept="image/*" @change="handleFileUpload">
            <img v-if="imageBytes" :src="imageUrl" alt="Preview" class="preview-image">
          </div>
          <button type="submit" class="btn">Cadastrar</button>
        </form>
      </div>
    </div>
  </template>

<style scoped>

body.dark {
  background-color: #111;
  color: white;
}

.container {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
}

.container.dark {
  background-color: #222;
  border-radius: 8px;
}

form {
  background-color: #fff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

form.dark {
  background-color: #333;
  color: white;
}

input,
textarea,
button {
  background-color: #f8f9fa;
  border: 1px solid #ddd;
  padding: 10px;
  border-radius: 4px;
  width: 100%;
  box-sizing: border-box;
  margin-bottom: 15px;
}

form.dark input,
form.dark textarea,
form.dark button {
  background-color: #444;
  border: 1px solid #666;
  color: white;
}

input[type="text"],
input[type="number"],
textarea {
  color: #333;
}

form.dark input[type="text"],
form.dark input[type="number"],
form.dark textarea {
  color: white;
}

button {
  background-color: #007bff;
  color: white;
  cursor: pointer;
  border-radius: 4px;
  padding: 10px;
}

form.dark button {
  background-color: #0056b3;
}

label {
  color: #222;
  font-weight: bold;
  margin-bottom: 8px;
  display: block;
}

form.dark label {
  color: white;
}

input,
textarea,
button,
label {
  transition: background-color 0.3s, color 0.3s, border 0.3s;
}

form.dark img {
  max-width: 300px;
  border-radius: 4px;
  margin-top: 10px;
}

input:focus,
textarea:focus,
button:focus {
  border-color: #007bff;
  outline: none;
}

form.dark input:focus,
form.dark textarea:focus,
form.dark button:focus {
  border-color: #0056b3;
}

form {
  max-width: 600px;
  margin: 0 auto;
}

.container.dark {
  padding: 30px;
}
</style>

