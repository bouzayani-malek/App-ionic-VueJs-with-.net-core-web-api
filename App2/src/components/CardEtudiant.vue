<template>
  <ion-item-sliding>
    <!--slide delete -->
    <ion-item-options side="start">
      <ion-item-option @click="SupprimerEtudiant(Etudiant,Etudiant.idEtudiant)" color="danger" expandable>
        <ion-icon slot="icon-only" :icon="trash"></ion-icon>
      </ion-item-option>
    </ion-item-options>
    <!--fin slide delete -->
    <!--nom de item -->
    <ion-item>
      <ion-label
        >{{ Etudiant.prenom }} {{ Etudiant.nom }}
        {{ Etudiant.classe }}</ion-label
      >
    </ion-item>
    <!--fin nom -->
    <!--slide edit -->
    <ion-item-options side="end">
      <ion-item-option color="tertiary" @click="UpdateEtudiant(Etudiant.idEtudiant)" expandable>
        <ion-icon slot="icon-only" :icon="openOutline"></ion-icon>
      </ion-item-option>
    </ion-item-options>
    <!--fin slide edit -->
  </ion-item-sliding>
</template>
<script>
import {
  IonItemSliding,
  IonItemOptions,
  IonItemOption,
  IonIcon,
  IonLabel,
} from "@ionic/vue";
import { cart, trash, openOutline } from "ionicons/icons";
import { defineComponent } from "vue";
import axios from "axios";
export default defineComponent({
  props: ["Etudiant"],
  data() {
    return {
      cart,
      openOutline,
      trash,
      //Shearsh:"ff"
    };
  },
  components: {
    IonItemSliding,
    IonItemOptions,
    IonItemOption,
    IonIcon,
    IonLabel,
  },
  methods:{
    SupprimerEtudiant(etudiant,id){
       axios
        .delete("https://localhost:44300/api/Etudiants/" + id)
        .then((res) => console.log(res))
        .catch((rer) => console.log(rer));
      this.$store.dispatch('Get_Delete_Etudiant',etudiant);
    },
   UpdateEtudiant(id){
      this.$router.push({ name: "EditEtudiant", params: { id: id } });
    }
  }
});
</script>

<style>
ion-toolbar {
  --background: #e5c234;
  --border-style: none;
  --opacity: 0.8;
  --color: red;
}
</style>