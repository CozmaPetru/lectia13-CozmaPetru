// Lecția 12. Validarea în browser, potrivită culturii ro-MD.
// jQuery Validation acceptă implicit doar punctul zecimal: „312500,50” ar fi respins.
// Aici regula „număr” acceptă virgula, ca serverul. Nu modifica acest fișier.
$.validator.methods.number = function (valoare, element) {
    return this.optional(element) || /^-?\d+(,\d+)?$/.test(valoare);
};
