import { RECEIVE_DECKS, ADD_DECK, ADD_CARD, DELETE_DECK } from 'types';

export function receiveDecks(decks) {
	return {
		type: RECEIVE_DECKS,
		decks
	};
}

export function addDeck(deck) {
	return {
		type: ADD_DECK,
		deck
	};
}

export function addCard(card) {
	return {
		type: ADD_CARD,
		card
	};
}

export function deleteDeck(deck) {
	return {
		type: DELETE_DECK
	};
}
