<script setup>
import TitleCard from '../components/TitleCard.vue'
import { ref, reactive, onMounted } from 'vue';

let obras = reactive(ref());

onMounted(async ()=>{
    try {
        const response = await fetch('https://localhost:7071/api/ScrollsTracker/Obras');
        
        if (!response.ok) throw new Error(await response.text());

        var json = await response.json();
        obras.value = json;

    }catch (error) {
        console.error('Erro:', error);
    }
})


</script>

<template>
    <div>
        <div class="container text-body-secondary">
            <div class="row mt-4">
                <div class="col-sm-12 col-md-6">
                    <TitleCard
                    v-for="obra in obras"
                    :key="obra.id"
                    :titulo="obra.titulo"
                    :descricao="obra.descricao"
                    :totalCapitulos="obra.totalCapitulos"
                    :ultimoCapituloLido="obra.ultimoCapituloLido"
                    :imagem="obra.imagem"
                    />
                </div>
            </div>
        </div>
    </div>
</template>

<style>
    
</style>