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
    <div>
        <div class="container">
            <h1>Cadastrar</h1>
            <div class="row">
                <div class="col-sm-12 col-md-6">
                    <form>
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
                            <input type="file" class="form-control mb-3" id="imagem" accept="image/*" @change="handleFileUpload">
                            <img v-if="imageBytes" :src="imageUrl" alt="Preview" style="max-width: 300px;">
                        </div>
                        <button type="submit" class="btn btn-primary" @click="cadastrar($event)">Cadastrar</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<style>
    
</style>