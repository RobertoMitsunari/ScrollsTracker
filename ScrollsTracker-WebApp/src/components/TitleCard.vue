    <script setup>
        import { defineProps } from 'vue';
        const obra = defineProps(["titulo", "descricao", "totalCapitulos", "ultimoCapituloLido", "imagem"]); 
    </script>

    <template lang="">
        <div>
            <div class="card mb-3" style="max-width: 540px;">
                <div class="row g-0">
                    <div class="col-md-4">
                        <img :src="`https://localhost:7071/api/ScrollsTracker${obra.imagem}`" class="img-fluid rounded-start object-fit-cover" alt="...">
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title">{{titulo}}</h5>
                            <p class="card-text">{{descricao}}</p>
                            <p class="card-text"><small class="text-body-secondary">Total Capitulos: {{totalCapitulos}} Ultimo Capítulo: {{ultimoCapituloLido}}</small></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </template>

    <style scoped>

    </style>