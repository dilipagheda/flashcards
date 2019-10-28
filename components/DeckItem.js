import React, { Component } from 'react';
import { StyleSheet, View, Text, TouchableOpacity } from 'react-native';
import { purple, white } from '../utils/colors';

class DeckItem extends Component {
	render() {
		return (
			<TouchableOpacity style={styles.item} onPress={this.props.showDetail}>
				<View>
					<Text style={styles.itemHeader}>Deck 1</Text>
					<Text style={styles.itemFooter}>0 cards</Text>
				</View>
			</TouchableOpacity>
		);
	}
}

const styles = StyleSheet.create({
	item: {
		alignSelf: 'stretch',
		borderWidth: 1,
		padding: 10,
		borderRadius: 5,
		borderColor: purple,
		margin: 10
	},
	itemHeader: {
		textAlign: 'center',
		fontSize: 25
	},
	itemFooter: {
		textAlign: 'center',
		fontSize: 20
	}
});

export default DeckItem;
