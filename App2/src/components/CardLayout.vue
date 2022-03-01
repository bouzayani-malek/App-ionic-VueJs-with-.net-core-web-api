<template>
  <ion-card>
    <ion-card-header>
      <ion-img
      :src="require(`../../public/assets/${livre.image}`)"   
      ></ion-img>

      <ion-card-subtitle>
        <br />
        <div class="cent">
        Isbm :{{ livre.isbm }} / Année : {{ livre.anneeEdition }} / Nombre :{{
          nombre()
        }}
        </div></ion-card-subtitle
      >
      <ion-card-title class="cent">{{ livre.titre }} </ion-card-title>
    </ion-card-header>

    <ion-card-content>
      <ion-item
        >{{ livre.resume }}
        <ion-buttons slot="end">
          <ion-button
            color="danger"
            @click="
              supprimer(livre,livre.idLivre);"
          >
            <ion-icon :icon="trash" slot="icon-only"></ion-icon>
          </ion-button>
          <slot name="slot-1" />
        </ion-buttons>
      </ion-item>
    </ion-card-content>
  </ion-card>
</template>

<script>
import axios from "axios";
import {
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonCardSubtitle,
  IonCardTitle,
} from "@ionic/vue";
//import { pin, walk, warning, wifi, wine } from 'ionicons/icons';
import { defineComponent } from "vue";
import { trash } from "ionicons/icons";

export default defineComponent({
  props: ["livre","nombreEmpreinte"],
  data() {
    return {
      trash,
      
    };
  },
  components: {
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardSubtitle,
    IonCardTitle,
  },
  methods: {
    supprimer(livre,id) {
      axios
        .delete("https://localhost:44300/api/livres/" + id)
        .then((res) => console.log(res))
        .catch((rer) => console.log(rer));
      this.$store.dispatch('Get_Delete',livre);
    },
    nombre(){
       return  this.livre.nombre-this.nombreEmpreinte;
    }
  },
});
</script>
<style>
.cent{
  text-align: center;
}
</style>